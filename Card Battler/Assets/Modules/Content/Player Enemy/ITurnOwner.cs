using Modules.Content.Deck;

namespace Modules.Content.Player_Enemy
{
    public interface ITurnOwner
    {
        bool IsActive { get; }
        int DrawCardsAmountInDrawPhase { get; }
        IDeck Deck { get; }
    }
}