using System;
using System.Collections;
using Modules.Content.Deck;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Turn_System
{
    public class TurnSystem : IInitializable,IDisposable
    {
        private readonly ActionSystem _actionSystem;
        private readonly IManaSystem _manaSystem;
        private readonly IDeck _deck;
        
        [Inject]
        public TurnSystem(ActionSystem actionSystem, IManaSystem manaSystem, IDeck deck)
        {
            _actionSystem = actionSystem;

            _manaSystem = manaSystem;

            _deck = deck;
        }
        
        public void Initialize()
        {
            _actionSystem.AttachPerformer<PlayerStartTurnGA>(StartPlayerTurnPerformer);
            _actionSystem.AttachPerformer<PlayerEndTurnGA>(PlayerEndTurnPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<PlayerStartTurnGA>();
            _actionSystem.DetachPerformer<PlayerEndTurnGA>();
        }

        private IEnumerator StartPlayerTurnPerformer(PlayerStartTurnGA playerEndTurnGa)
        {
            _manaSystem.RefillMana();

            DrawCardsGA drawCardsGa = new(5, _deck);
            
            _actionSystem.AddReaction(drawCardsGa);

            yield return null;
        }

        private IEnumerator PlayerEndTurnPerformer(PlayerEndTurnGA playerEndTurnGa)
        {
            yield return new WaitForSeconds(2f);

            PlayerStartTurnGA playerStartTurnGa = new();
            
            _actionSystem.AddReaction(playerStartTurnGa);
        }
    }
}