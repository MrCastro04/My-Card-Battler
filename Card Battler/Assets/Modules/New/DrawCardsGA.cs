using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.New.Game_Actions
{
    public class DrawCardsGA : GameAction
    {
        public readonly int DrawAmount;

        public DrawCardsGA(int drawAmount)
        {
            DrawAmount = drawAmount;
        }
    }
}