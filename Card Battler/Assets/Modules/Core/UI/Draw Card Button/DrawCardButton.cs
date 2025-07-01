using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class DrawCardButton : MonoBehaviour
    {
        [Inject] private ActionSystem _actionSystem;
        
        public void OnClick()
        {
            DrawCardsGA drawCardsGa = new(1);
            
            _actionSystem.Perform(drawCardsGa);
        }
    }
}
