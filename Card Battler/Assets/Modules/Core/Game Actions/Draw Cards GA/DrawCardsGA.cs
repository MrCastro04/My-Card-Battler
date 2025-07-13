using Modules.Content.Deck;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.Core.Game_Actions.Draw_Cards_GA
{
    public class DrawCardsGA : GameAction
    {
        public readonly int DrawAmount;
        public readonly IDeck Deck;
        
        public DrawCardsGA(int drawAmount, IDeck deck )
        {
            DrawAmount = drawAmount;

            Deck = deck;
        }
    }
}