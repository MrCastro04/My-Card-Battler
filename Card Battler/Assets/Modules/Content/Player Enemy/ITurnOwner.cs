using Modules.Content.Deck;

namespace Modules.Content.Player_Enemy
{
    public interface ITurnOwner
    {
        int DrawCardsAmountInDrawPhase { get; }
        IDeck Deck { get; }
    }
}