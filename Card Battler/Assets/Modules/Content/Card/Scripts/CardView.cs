using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Highlight_Card_System;
using Modules.New;
using TMPro;
using UnityEngine;
using Zenject;

namespace Modules.Content.Card.Scripts
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mana;
        [SerializeField] private TMP_Text _unitHealth;
        [SerializeField] private TMP_Text _unitDamage;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private GameObject _wrapper;
        [SerializeField] private GameObject _healthBlock;
        [SerializeField] private GameObject _damageBlock;
        [SerializeField] private LayerMask _playZoneMask;

        private IHighlightCardSystem _highlightCardSystem;
        private ICardInteractions _cardInteractions;
        private ActionSystem _actionSystem;
        private Vector3 _positionBeforeDrag;
        private Quaternion _rotationBeforeDrag;

        public CardModel CardModel { get; private set; }

        [Inject]
        private void Construct(
            IHighlightCardSystem highlightCardSystem,
            ICardInteractions cardInteractions,
            ActionSystem actionSystem)
        {
            _highlightCardSystem = highlightCardSystem;

            _cardInteractions = cardInteractions;

            _actionSystem = actionSystem;
        }

        public void Setup(CardModel cardModel)
        {
            CardModel = cardModel;

            switch (CardModel.CardData)
            {
                case (UnitCardData unitCardData):

                    if (_healthBlock.activeSelf == false && _damageBlock.activeSelf == false)
                    {
                        _healthBlock.SetActive(true);

                        _damageBlock.SetActive(true);
                    }

                    _unitHealth.text = unitCardData.HealthAmount.ToString();

                    _unitDamage.text = unitCardData.DamageAmount.ToString();

                    break;

                case (SpellCardData spellCardData):

                    if (_healthBlock.activeSelf && _damageBlock.activeSelf)
                    {
                        _healthBlock.SetActive(false);

                        _damageBlock.SetActive(false);
                    }

                    break;
            }

            _mana.text = cardModel.ManaAmount.ToString();

            _name.text = cardModel.Name;

            _spriteRenderer.sprite = cardModel.Image;
        }

        private void OnMouseEnter()
        {
            if (_cardInteractions.CanHover() == false)
                return;

            _wrapper.SetActive(false);

            Vector3 highlightPos = new(transform.position.x, transform.position.y + 2, transform.position.z);

            _highlightCardSystem.Show(CardModel, highlightPos);
        }

        private void OnMouseExit()
        {
            if (_cardInteractions.CanHover() == false)
                return;

            _highlightCardSystem.Hide();

            _wrapper.SetActive(true);
        }

        private void OnMouseDown()
        {
            if (_cardInteractions.CanInteract() == false)
                return;

            _cardInteractions.SetDragStatus(true);

            _wrapper.SetActive(true);

            _highlightCardSystem.Hide();

            _rotationBeforeDrag = transform.rotation;

            _positionBeforeDrag = transform.position;

            transform.rotation = Quaternion.identity;

            transform.position = _cardInteractions.MouseUtil.GetMousePositionInWorldSpace(-1);
        }

        private void OnMouseDrag()
        {
            if (_cardInteractions.CanInteract() == false)
                return;

            transform.position = _cardInteractions.MouseUtil.GetMousePositionInWorldSpace(-1);
        }

        private void OnMouseUp()
        {
            if (_cardInteractions.CanInteract() == false)
                return;

            if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hitInfo, 10f, _playZoneMask)
                && hitInfo.collider != null
                && _cardInteractions.CanPlayCard(CardModel.ManaAmount))
            {
                if (hitInfo.collider.TryGetComponent(out SlotPlayUnitMono slotPlayUnitMono))
                {
                    if (slotPlayUnitMono.IsOccupied == false)
                    {
                        PlayCardGA playCardGa = new(this, hitInfo);

                        _actionSystem.Perform(playCardGa);
                    }
                    else
                    {
                        transform.rotation = _rotationBeforeDrag;

                        transform.position = _positionBeforeDrag;
                    }
                }
            }
            
            else
            {
                transform.rotation = _rotationBeforeDrag;

                transform.position = _positionBeforeDrag;
            }

            _cardInteractions.SetDragStatus(false);
        }

        public void DisableCollider()
        {
            Collider collider = gameObject.GetComponent<Collider>();

            collider.enabled = false;
        }
    }
}