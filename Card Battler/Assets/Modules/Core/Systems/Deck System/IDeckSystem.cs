using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Content.Deck;

namespace Modules.Core.Systems.Deck_System
{
    public interface IDeckSystem
    {
        DeckUnitsMono DeckUnitsMono { get; }
        CardModel GetCardModel(Queue<CardModel> deck);
    }
}