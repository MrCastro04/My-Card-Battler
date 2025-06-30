using System.Collections;
using Modules.Core.Game_Actions;

namespace Modules.New
{
    public interface IDrawCardSystem
    {
        IEnumerator DrawCardsPerformer(DrawCardsGA drawCardsGa);
    }
}