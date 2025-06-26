using System.Collections;
using Modules.Content.Card.Scripts;

namespace Modules.Content.Hand
{
    public interface IHand
    {
        IEnumerator AddCard(CardView cardView);
    }
}