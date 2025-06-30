using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.New
{
    public class DiscardCardsGA : GameAction
    {
        public readonly int DiscardAmount;
        public readonly bool IsAllCardsInHand = false;

        public DiscardCardsGA(int discardAmount, bool isAllCardsInHand = false)
        {
            DiscardAmount = discardAmount;

            IsAllCardsInHand = isAllCardsInHand;
        }
    }
}