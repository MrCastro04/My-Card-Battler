using System;
using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using Modules.Core.Factories;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Card_System.Sub_Systems;
using Modules.Core.Systems.Deck_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Card_System
{
    public sealed class CardSystem : IInitializable, IDisposable
    {
        private readonly DeckSystem _deckSystem;
        private readonly DrawCardSystem _drawCardSystem;
        private readonly IHighlightCardSystem _highlightCardSystem;
        private readonly ActionSystem _actionSystem;
        private readonly ICardViewFactory _cardViewFactory;
        private readonly IHand _hand;

        [Inject]
        public CardSystem(
            ActionSystem actionSystem,
            DeckSystem deckSystem ,
            DrawCardSystem drawCardSystem ,
            IHighlightCardSystem highlightCardSystem ,
            ICardViewFactory cardViewFactory,
            IHand hand)
        {
            _actionSystem = actionSystem;
            _deckSystem = deckSystem;
            _cardViewFactory = cardViewFactory;
            _hand = hand;
            _drawCardSystem = drawCardSystem;
            _highlightCardSystem = highlightCardSystem;
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<DrawCardsGA>(_drawCardSystem.DrawCardsPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<DrawCardsGA>();
        }

        public void ShowCard(CardModel cardModel, Vector3 at) => _highlightCardSystem.Show(cardModel,at);
        public void HideCard() => _highlightCardSystem.Hide();
    }
}