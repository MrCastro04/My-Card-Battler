using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.Core.Game_Actions.Discard_Cards_GA
{
    public class DiscardCardsGA : GameAction
    {
        public readonly CardView SelectedCardView = null;
        public readonly bool IsAllCardsInHand = false;

        public DiscardCardsGA(bool isAllCardsInHand)
        {
            IsAllCardsInHand = isAllCardsInHand;
        }

        public DiscardCardsGA(CardView selectedCardView)
        {
            SelectedCardView = selectedCardView;
        }
    }
}