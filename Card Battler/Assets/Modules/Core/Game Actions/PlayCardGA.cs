using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.Core.Game_Actions
{
    public class PlayCardGA : GameAction
    {
        public readonly CardView PlayedCardView;

        public PlayCardGA(CardView playedCardView)
        {
            PlayedCardView = playedCardView;
        }
    }
}