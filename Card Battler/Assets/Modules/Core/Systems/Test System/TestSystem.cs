using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using Modules.Core.Factories;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Test_System
{
    public class TestSystem : MonoBehaviour , IInitializable
    {
        [SerializeField] private CardData _cardData;
        
        private ICardViewFactory _cardViewFactory;
        private IHand _hand;
        
        [Inject]
        private void Construct(ICardViewFactory cardViewFactory,IHand hand) 
        {
            _cardViewFactory = cardViewFactory;

            _hand = hand;
        }

        public void Initialize()
        {
            _cardViewFactory.Load();
            
            for (int i = 0; i < 3; i++)
            {
                CardView cardView = _cardViewFactory.Create(new(_cardData), _hand.HandPosition);

                StartCoroutine(_hand.AddCard(cardView));
            }
        }
    }
}