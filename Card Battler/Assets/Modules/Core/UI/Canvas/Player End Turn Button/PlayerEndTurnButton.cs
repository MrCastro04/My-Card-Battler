using Modules.Core.Game_Actions.Player_End_Turn_GA;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.UI.Canvas.Player_End_Turn_Button
{
    public class PlayerEndTurnButton : MonoBehaviour
    {
        [Inject] private ActionSystem _actionSystem;
        
        public void OnClick()
        {
            PlayerEndTurnGA playerEndTurnGa = new();
            
            _actionSystem.Perform(playerEndTurnGa);
        }
    }
}