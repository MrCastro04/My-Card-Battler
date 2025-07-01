using Modules.Core.Factories;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
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

            DrawCardsGA drawCardsGa = new(3);
            
            _actionSystem.AddReaction(drawCardsGa);
            
            _actionSystem.Perform(drawCardsGa);
        }
    }
}