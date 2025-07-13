using Modules.Content.Deck;
using Modules.Core.Game_Actions.Draw_Cards_GA;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.UI.Canvas.Draw_Card_Button
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
