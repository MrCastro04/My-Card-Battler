using System.Collections.Generic;
using System.Linq;
using Modules.Content.Card.Scripts;
using Modules.Content.Deck;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Deck_System
{
    public sealed class DeckSystem : IDeckSystem
    {
        public DeckUnitsMono DeckUnitsMono { get; }
        public Vector3 Position => DeckUnitsMono.transform.position;

        [Inject]
        public DeckSystem(List<BaseCardData> startDeckUnitsData, DeckUnitsMono deckUnitsMono)
        {
            DeckUnitsMono = deckUnitsMono;

            DeckUnitsMono.Setup(InitializeDeck(startDeckUnitsData));
        }

        public CardModel GetCardModel(Queue<CardModel> deck)
        {
            return deck.Dequeue();
        }

        private Queue<CardModel> InitializeDeck(List<BaseCardData> startDeckData)
        {
            List<CardModel> shuffledList = startDeckData
                .Select(data => new CardModel(data))
                .OrderBy(model => Random.Range(0, startDeckData.Count))
                .ToList();

            Queue<CardModel> initializedDeck = new(shuffledList);

            return initializedDeck;
        }
    }
}