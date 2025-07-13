using System;
using Modules.Core.Game_Actions;
using Modules.Core.Game_Actions.Draw_Cards_GA;
using Modules.Core.Game_Actions.Play_Cards_GA;
using Modules.Core.Game_Actions.Player_End_Turn_GA;
using Modules.Core.Game_Actions.Player_Start_Turn_GA;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Deck_System;
using Modules.Core.Systems.Mana_System;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Debug_System
{
    public class DebugSystem : IInitializable, IDisposable
    {
        private readonly ActionSystem _actionSystem;
        private readonly DeckSystem _deckSystem;
        private readonly IManaSystem _manaSystem;

        [Inject]
        public DebugSystem(ActionSystem actionSystem, DeckSystem deckSystem, IManaSystem manaSystem)
        {
            _actionSystem = actionSystem;

            _deckSystem = deckSystem;

            _manaSystem = manaSystem;
        }

        public void Initialize()
        {
            _actionSystem.SubscribeReaction<DrawCardsGA>(POSTDrawCardReaction, ReactionTiming.POST);
            _actionSystem.SubscribeReaction<PlayCardGA>(POSTPlayCardReaction, ReactionTiming.POST);
            _actionSystem.SubscribeReaction<PlayerStartTurnGA>(POSTPlayerStartTurnReaction, ReactionTiming.POST);
            _actionSystem.SubscribeReaction<PlayerEndTurnGA>(PREPlayerEndTurnReaction, ReactionTiming.PRE);
        }

        public void Dispose()
        {
            _actionSystem.UnsubscribeReaction<DrawCardsGA>(POSTDrawCardReaction, ReactionTiming.POST);
            _actionSystem.UnsubscribeReaction<PlayCardGA>(POSTPlayCardReaction, ReactionTiming.POST);
            _actionSystem.UnsubscribeReaction<PlayerStartTurnGA>(POSTPlayerStartTurnReaction, ReactionTiming.POST);
            _actionSystem.UnsubscribeReaction<PlayerEndTurnGA>(PREPlayerEndTurnReaction,ReactionTiming.PRE);
        }

        private void POSTDrawCardReaction(DrawCardsGA drawCardsGa)
        {
            Debug.Log($"Cards in Units Deck - {_deckSystem.DeckUnitsMono.Deck.Count}");
        }

        private void POSTPlayerStartTurnReaction(PlayerStartTurnGA playerEndTurnGa)
        {
            Debug.Log($"Current Mana - {_manaSystem.CurrentMana}");
            
        }

        private void PREPlayerEndTurnReaction(PlayerEndTurnGA playerEndTurnGa)
        {
            Debug.Log("Player End Turn");
        }

        private void POSTPlayCardReaction(PlayCardGA playCardGa)
        {
            Debug.Log($"Current Mana After Cast - {_manaSystem.CurrentMana}");
        }
    }
}