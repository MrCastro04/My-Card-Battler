using System.Collections;
using Modules.Core.Game_Actions;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Play_Card_System
{
    public interface IPlayCardSystem
    {
        IEnumerator PlayCardPerformer(PlayCardGA playCardGa);
    }
}