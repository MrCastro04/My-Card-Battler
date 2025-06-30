using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Core.Systems.Discard_Pile_System
{
    public interface IDiscardPileSystem
    {
        Queue<CardModel> CardsInDiscardPile { get; }
        Vector3 Position { get; }
        void AddCardInDiscard(CardView cardView);
    }
}