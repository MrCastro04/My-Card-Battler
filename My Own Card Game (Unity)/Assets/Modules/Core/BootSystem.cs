using Modules.Content.Card.Scripts;
using Modules.Content.Card.Scripts.Card_View;
using Modules.Content.Card.Scripts.Models;
using UnityEngine;

namespace Modules.Core
{
    public class BootSystem : MonoBehaviour
    {
        [SerializeField] private CardView _cardView;
        [SerializeField] private CardData _cardData;
        
        private void Start()
        {
            CardModel cardModel = new(_cardData);
            
            _cardView.Setup(cardModel);
        }
    }
}