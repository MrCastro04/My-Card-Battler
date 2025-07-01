using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.New;
using TMPro;
using UnityEngine;
using Zenject;

namespace Modules.Content.Card.Scripts
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _mana;
        [SerializeField] private TMP_Text _name;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private GameObject _wrapper;
        [SerializeField] private LayerMask _playZoneMask;

        private IHighlightCardSystem _highlightCardSystem;
        private ICardInteractions _cardInteractions;
        private ActionSystem _actionSystem;
        private Vector3 _positionBeforeDrag;
        private Quaternion _rotationBeforeDrag;

        public CardModel CardModel { get; private set; }

        [Inject]
        private void Construct(IHighlightCardSystem highlightCardSystem, ICardInteractions cardInteractions,
            ActionSystem actionSystem)
        {
            _highlightCardSystem = highlightCardSystem;

            _cardInteractions = cardInteractions;

            _actionSystem = actionSystem;
        }

        public void Setup(CardModel cardModel)
        {
            CardModel = cardModel;

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
                && hitInfo.collider != null)
            {
                DisableCollider();
                
                DiscardCardsGA discardCardsGa = new(this);

                _actionSystem.Perform(discardCardsGa);
            }
            else
            {
                transform.rotation = _rotationBeforeDrag;

                transform.position = _positionBeforeDrag;
            }

            _cardInteractions.SetDragStatus(false);
        }

        private void DisableCollider()
        {
            Collider collider = gameObject.GetComponent<Collider>();

            collider.enabled = false; 
        }
    }
}