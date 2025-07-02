using System.Collections.Generic;
using Modules.Content.Card.Scripts;

namespace Modules.Content.Deck
{
    public interface IDeck
    {
        Queue<CardModel> Deck { get; }
        void Setup(Queue<CardModel> deck);
    }
}