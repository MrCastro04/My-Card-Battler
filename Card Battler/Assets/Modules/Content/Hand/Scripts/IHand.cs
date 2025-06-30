using System.Collections;
using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Content.Hand.Scripts
{
    public interface IHand
    {
        List<CardView> CardsViewInHand { get; }
        Vector3 Position { get; }
        IEnumerator AddCard(CardView cardView);
        IEnumerator RemoveCard(CardView cardView);
    }
}