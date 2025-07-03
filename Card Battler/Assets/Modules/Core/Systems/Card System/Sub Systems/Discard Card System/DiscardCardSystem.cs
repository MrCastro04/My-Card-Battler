using System.Collections;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Discard_Pile_System;
using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Discard_Card_System
{
    public class DiscardCardSystem : IDiscardCardSystem
    {
        private readonly DiscardPileSystem _discardPileSystem;
        private readonly IHand _hand;

        [Inject]
        public DiscardCardSystem(DiscardPileSystem discardPileSystem, IHand hand)
        {
            _discardPileSystem = discardPileSystem;

            _hand = hand;
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
            else
            {
                yield return DiscardCard(discardCardsGa.SelectedCardView);
            }
        }

        private IEnumerator DiscardCard(CardView discardedCardView)
        {
            Tween tween = discardedCardView.transform.DOMove(_discardPileSystem.Position, 0.15f);

            _discardPileSystem.AddCardInDiscard(discardedCardView);

            yield return tween.WaitForCompletion();

            yield return _hand.RemoveCard(discardedCardView);
        }
    }
}