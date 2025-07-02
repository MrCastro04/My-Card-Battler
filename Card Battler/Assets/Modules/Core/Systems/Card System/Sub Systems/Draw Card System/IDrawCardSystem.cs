using System.Collections;
using Modules.Core.Game_Actions;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Draw_Card_System
{
    public interface IDrawCardSystem
    {
        IEnumerator DrawCardsPerformer(DrawCardsGA drawCardsGa);
    }
}