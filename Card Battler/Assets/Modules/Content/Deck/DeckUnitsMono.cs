using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Content.Deck
{
    public class DeckUnitsMono : MonoBehaviour, IDeck
    {
        private Queue<CardModel> _unitCardsInDeck;
        public Queue<CardModel> Deck => _unitCardsInDeck;

        public void Setup(Queue<CardModel> deckUnits)
        {
            _unitCardsInDeck = deckUnits;
        }
    }
}