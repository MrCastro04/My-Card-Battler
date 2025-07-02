using Modules.Content.Deck;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class DrawCardButton : MonoBehaviour
    {
         private ActionSystem _actionSystem;
         private IDeck _deck;

        [Inject]
        private void Construct(ActionSystem actionSystem, IDeck deck)
        {
            _actionSystem = actionSystem;

            _deck = deck;
        }
        
        public void OnClick()
        {
            DrawCardsGA drawCardsGa = new(1,_deck);
            
            _actionSystem.Perform(drawCardsGa);
        }
    }
}
