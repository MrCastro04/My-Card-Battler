using System.Collections.Generic;
using System.Linq;
using Modules.Content.Card.Scripts;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Deck_System
{
    public sealed class DeckSystem : IDeckSystem
    {
        private Queue<CardModel> _deck;
        
        public Vector3 Position => Vector3.zero;

       [Inject]
       public DeckSystem(List<CardData> startDeckData)
        {
            _deck = new();

            Setup(startDeckData);
            
            Debug.Log($"Cards in deck - {_deck.Count}");
        }

        public CardModel GetCardModel()
        {
            return _deck.Dequeue();
        }

        private void Setup(List<CardData> deckData)
        {
            List<CardModel> shuffledDeck = deckData
                .Select(data => new CardModel(data))
                .OrderBy(data => Random.Range(0, deckData.Count))
                .ToList();

            _deck = new(shuffledDeck);
        }
    }
}