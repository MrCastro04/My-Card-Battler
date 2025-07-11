using Modules.Content.Deck;

namespace Modules.New
{
    public class Player : ITurnOwner
    {
        private IDeck _deck;
        private int _drawCardsInDrawPhase;

        public int DrawCardsAmountInDrawPhase => _drawCardsInDrawPhase;
        public IDeck Deck => _deck;

        public Player(IDeck deck, int drawCardsInDrawPhase)
        {
            _deck = deck;
            _drawCardsInDrawPhase = drawCardsInDrawPhase;
        }
    }
}