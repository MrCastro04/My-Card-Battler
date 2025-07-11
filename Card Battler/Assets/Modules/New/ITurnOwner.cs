using Modules.Content.Deck;

namespace Modules.New
{
    public interface ITurnOwner
    {
        int DrawCardsAmountInDrawPhase { get; }
        IDeck Deck { get; }
    }
}