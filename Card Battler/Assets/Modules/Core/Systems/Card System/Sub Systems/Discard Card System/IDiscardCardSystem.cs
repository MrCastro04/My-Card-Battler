using System.Collections;
using Modules.Core.Game_Actions;

namespace Modules.New
{
    public interface IDiscardCardSystem
    {
        IEnumerator DiscardCardPerformer(DiscardCardsGA discardCardsGa);
    }
}