using System;
using Modules.Content.Hand.Scripts;
using Modules.Core.Factories;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Card_System;
using Modules.New.Game_Actions;
using Zenject;

namespace Modules.New.Card_System
{
    public class CardSystem : IInitializable, IDisposable
    {
        private readonly DeckSystem _deckSystem;
        private readonly DrawCardSystem _drawCardSystem;
        private readonly ActionSystem _actionSystem;
        private readonly ICardViewFactory _cardViewFactory;
        private readonly IHand _hand;

        [Inject]
        public CardSystem(ActionSystem actionSystem, DeckSystem deckSystem,ICardViewFactory cardViewFactory, IHand hand)
        {
            _actionSystem = actionSystem;
            _deckSystem = deckSystem;
            _cardViewFactory = cardViewFactory;
            _hand = hand;
            
            _drawCardSystem = new(_deckSystem,_cardViewFactory,_hand);
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<DrawCardsGA>(_drawCardSystem.DrawCardsPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<DrawCardsGA>();
        }
    }
}