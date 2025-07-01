using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.New
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