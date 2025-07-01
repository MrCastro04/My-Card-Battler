using System.Collections.Generic;
using Modules.Content;
using Modules.Content.Card.Scripts;

namespace Modules.New
{
    public interface IDeckSystem
    {
        DeckMono DeckMono { get; }
        Queue<CardModel> UnitsDeck { get; }
        CardModel GetCardModel();
    }
}