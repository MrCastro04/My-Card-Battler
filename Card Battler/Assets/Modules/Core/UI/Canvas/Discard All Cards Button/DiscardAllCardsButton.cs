using Modules.Core.Game_Actions.Discard_Cards_GA;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.UI.Canvas.Discard_All_Cards_Button
{
    public class DiscardAllCardsButton : MonoBehaviour
    {
        [Inject] private ActionSystem _actionSystem;

        public void OnClick()
        {
            DiscardCardsGA discardCardsGa = new(true);
            
            _actionSystem.Perform(discardCardsGa);
        } 
    }
}