using Modules.Core.Systems.Card_System;
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

        private CardSystem _cardSystem;
        private CardModel _cardModel;
        
        [Inject]
        private void Construct(CardSystem cardSystem)
        {
            _cardSystem = cardSystem;
        }
        
        public void Setup(CardModel cardModel)
        {
            _cardModel = cardModel;
            
            _mana.text = cardModel.ManaAmount.ToString();

            _name.text = cardModel.Name;

            _spriteRenderer.sprite = cardModel.Image;
        }

        private void OnMouseEnter()
        {
            _wrapper.SetActive(false);

            _cardSystem.ShowCard(_cardModel,Vector3.up);
        }
    }
}