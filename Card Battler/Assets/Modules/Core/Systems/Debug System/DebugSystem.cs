using System;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Deck_System;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Debug_System
{
    public class DebugSystem : IInitializable, IDisposable
    {
        private readonly ActionSystem _actionSystem;
        private readonly DeckSystem _deckSystem;
        
        [Inject]
        public DebugSystem(ActionSystem actionSystem, DeckSystem deckSystem)
        {
            _actionSystem = actionSystem;

            _deckSystem = deckSystem;
        }

        public void Initialize()
        {
            _actionSystem.SubscribeReaction<DrawCardsGA>(PostDrawCardReaction, ReactionTiming.POST);
        }

        public void Dispose()
        {
            _actionSystem.UnsubscribeReaction<DrawCardsGA>(PostDrawCardReaction, ReactionTiming.POST);
        }

        private void PostDrawCardReaction(DrawCardsGA drawCardsGa)
        {
            Debug.Log($"Cards in Units Deck - {_deckSystem.UnitsDeck.Count}");
        }
    }
}