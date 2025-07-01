using System.Collections.Generic;
using System.Linq;
using Modules.Content;
using Modules.Content.Card.Scripts;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Deck_System
{
    public sealed class DeckSystem : IDeckSystem
    {
        private Queue<CardModel> _unitsDeck;

        public DeckMono DeckMono { get; private set; }
        public Queue<CardModel> UnitsDeck => _unitsDeck;
        public Vector3 Position => DeckMono.transform.position;

        [Inject]
        public DeckSystem(List<CardData> startDeckData, DeckMono deckMono)
        {
            _unitsDeck = new();

            DeckMono = deckMono;

            Setup(startDeckData);
        }

        public CardModel GetCardModel()
        {
            return _unitsDeck.Dequeue();
        }

        private void Setup(List<CardData> deckData)
        {
            List<CardModel> shuffledDeck = deckData
                .Select(data => new CardModel(data))
                .OrderBy(data => Random.Range(0, deckData.Count))
                .ToList();

            _unitsDeck = new(shuffledDeck);
        }
    }
}