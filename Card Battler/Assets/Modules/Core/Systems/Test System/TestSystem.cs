using Modules.Content.Deck;
using Modules.Core.Factories;
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
        private IDeck _deck;

        [Inject]
        private void Construct(ICardViewFactory cardViewFactory, ActionSystem actionSystem, IDeck deck) 
        {
            _cardViewFactory = cardViewFactory;
            
            _actionSystem = actionSystem;

            _deck = deck;
        }

        public void Initialize()
        {
            _cardViewFactory.Load();

            DrawCardsGA drawCardsGa = new(3,_deck);
            
            _actionSystem.AddReaction(drawCardsGa);
            
            _actionSystem.Perform(drawCardsGa);
        }
    }
}