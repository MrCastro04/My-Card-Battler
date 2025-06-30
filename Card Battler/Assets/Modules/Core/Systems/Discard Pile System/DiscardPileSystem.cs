using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Discard_Pile_System
{
    public class DiscardPileSystem : IDiscardPileSystem
    {
        public Queue<CardModel> CardsInDiscardPile { get; }
        public Vector3 Position { get; }

        [Inject]
        public DiscardPileSystem(Vector3 position)
        {
            CardsInDiscardPile = new();

            Position = position;
        }

        public void AddCardInDiscard(CardView cardView)
        {
            CardsInDiscardPile.Enqueue(cardView.CardModel);
        }
    }
}