using System.Collections;
using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using Modules.Core.Factories;
using Modules.New;
using Modules.New.Game_Actions;

namespace Modules.Core.Systems.Card_System
{
    public class DrawCardSystem
    {
        private readonly DeckSystem _deckSystem;
        private readonly ICardViewFactory _cardViewFactory;
        private readonly IHand _hand;

        public DrawCardSystem(DeckSystem deckSystem, ICardViewFactory cardViewFactory, IHand hand)
        {
            _deckSystem = deckSystem;

            _cardViewFactory = cardViewFactory;

            _hand = hand;
        }

        public IEnumerator DrawCardsPerformer(DrawCardsGA drawCardsGa)
        {
            for (int i = 0; i < drawCardsGa.DrawAmount; i++)
                yield return Draw();
        }

        private IEnumerator Draw()
        {
            CardModel drawnCardModel = _deckSystem.GetCardModel();

            CardView newCardView = _cardViewFactory.Create(drawnCardModel, _deckSystem.Position);

            return _hand.AddCard(newCardView);
        }
    }
}