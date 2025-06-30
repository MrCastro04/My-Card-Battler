using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.New
{
    public interface IDiscardPileSystem
    {
        Queue<CardModel> CardsInDiscardPile { get; }
        Vector3 Position { get; }
        void AddCardInDiscard(CardView cardView);
    }
}