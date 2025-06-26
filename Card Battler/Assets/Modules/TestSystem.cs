using Modules.Content.Card.Scripts;
using Modules.Content.Hand;
using Modules.Core.Factories;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class TestSystem : MonoBehaviour
    {
        [SerializeField] private CardData _cardData;
        
        private ICardViewFactory _cardViewFactory;
        private IHand _hand;
        
        [Inject]
        private void Construct(ICardViewFactory cardViewFactory,IHand hand) 
        {
            _cardViewFactory = cardViewFactory;

            _hand = hand;
            
            _cardViewFactory.Load();

            for (int i = 0; i < 3; i++)
            {
                CardView cardView = _cardViewFactory.Create(new(_cardData), hand.HandPosition);

                StartCoroutine(_hand.AddCard(cardView));
            }
        }
    }
}