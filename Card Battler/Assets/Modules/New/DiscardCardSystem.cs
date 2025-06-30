using System.Collections;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using Zenject;

namespace Modules.New
{
    public class DiscardCardSystem : IDiscardCardSystem
    {
        private readonly DiscardPileSystem _discardPileSystem;
        private readonly IHand _hand;
        private readonly MonoDestroyer _monoDestroyer;

        [Inject]
        public DiscardCardSystem(DiscardPileSystem discardPileSystem, IHand hand, MonoDestroyer monoDestroyer)
        {
            _discardPileSystem = discardPileSystem;

            _hand = hand;

            _monoDestroyer = monoDestroyer;
        }

        public IEnumerator DiscardCardPerformer(DiscardCardsGA discardCardsGa)
        {
            if (discardCardsGa.IsAllCardsInHand)
            {
                CardView[] cardViewsArray = _hand.CardsViewInHand.ToArray();
                
                foreach (var cardView in cardViewsArray)
                {
                    yield return DiscardCard(cardView);
                }    
                
                _hand.CardsViewInHand.Clear();
            }
        }

        private IEnumerator DiscardCard(CardView discardedCardView)
        {
            Tween tween = discardedCardView.transform.DOMove(_discardPileSystem.Position, 0.15f);
            
            _discardPileSystem.AddCardInDiscard(discardedCardView);
            
            yield return tween.WaitForCompletion();

            yield return _hand.RemoveCard(discardedCardView);
            
            _monoDestroyer.Kill(discardedCardView.gameObject);
        }
    }
}