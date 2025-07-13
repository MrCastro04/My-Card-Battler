using System.Collections;
using Modules.Core.Game_Actions.Discard_Cards_GA;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Discard_Card_System
{
    public interface IDiscardCardSystem
    {
        IEnumerator DiscardCardPerformer(DiscardCardsGA discardCardsGa);
    }
}