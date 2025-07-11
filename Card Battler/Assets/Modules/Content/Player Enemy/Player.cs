using Modules.Content.Deck;

namespace Modules.Content.Player_Enemy
{
    public class Player : ITurnOwner
    {
        private IDeck _deck;
        private int _drawCardsInDrawPhase;

        public bool IsActive { get; } = false;
        public int DrawCardsAmountInDrawPhase => _drawCardsInDrawPhase;
        public IDeck Deck => _deck;

        public Player(IDeck deck, int drawCardsInDrawPhase)
        {
            _deck = deck;
            _drawCardsInDrawPhase = drawCardsInDrawPhase;
        }
    }
}