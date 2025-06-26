using System.Collections;
using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Content.Hand
{
    public interface IHand
    {
        Vector3 HandPosition { get; }
        IEnumerator AddCard(CardView cardView); 
    }
}