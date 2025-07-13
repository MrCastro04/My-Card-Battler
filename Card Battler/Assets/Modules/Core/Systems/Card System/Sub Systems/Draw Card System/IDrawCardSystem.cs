using System.Collections;
using Modules.Core.Game_Actions;
using Modules.Core.Game_Actions.Draw_Cards_GA;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Draw_Card_System
{
    public interface IDrawCardSystem
    {
        IEnumerator DrawCardsPerformer(DrawCardsGA drawCardsGa);
    }
}