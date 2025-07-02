using Modules.Content.Deck;
using Modules.Core.Factories;
using Modules.Core.Factories.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Deck_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Test_System
{
    public class TestSystem : MonoBehaviour , IInitializable
    {
        private ActionSystem _actionSystem;
        private ICardViewFactory _cardViewFactory;

        [Inject]
        private void Construct(ICardViewFactory cardViewFactory, ActionSystem actionSystem) 
        {
            _cardViewFactory = cardViewFactory;
            
            _actionSystem = actionSystem;
        }

        public void Initialize()
        {
            _cardViewFactory.Load();

            PlayerStartTurnGA playerStartTurnGa = new();
            
            _actionSystem.Perform(playerStartTurnGa);
        }
    }
}