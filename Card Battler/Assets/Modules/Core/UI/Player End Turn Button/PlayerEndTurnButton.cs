using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.UI.Player_End_Turn_Button
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