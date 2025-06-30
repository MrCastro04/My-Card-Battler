using System;
using Modules.Content.Hand.Scripts;
using Modules.Core.Factories;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Card_System
{
    public sealed class CardSystem : IInitializable, IDisposable
    {
        private readonly ActionSystem _actionSystem;
        private readonly IDeckSystem _deckSystem;
        private readonly IDrawCardSystem _drawCardSystem;
        private readonly IHighlightCardSystem _highlightCardSystem;
        private readonly ICardViewFactory _cardViewFactory;
        private readonly IHand _hand;

        [Inject]
        public CardSystem(
            ActionSystem actionSystem,
            IDeckSystem deckSystem ,
            IDrawCardSystem drawCardSystem ,
            IHighlightCardSystem highlightCardSystem ,
            ICardViewFactory cardViewFactory,
            IHand hand)
        {
            _actionSystem = actionSystem;
            _deckSystem = deckSystem;
            _drawCardSystem = drawCardSystem;
            _highlightCardSystem = highlightCardSystem;
            _cardViewFactory = cardViewFactory;
            _hand = hand;
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