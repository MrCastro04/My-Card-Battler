using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;

namespace Modules.New
{
    public class DiscardAllCardsButton : MonoBehaviour
    {
        [SerializeField] private ActionSystem _actionSystem;

        public void OnClick()
        {
            DiscardCardsGA discardCardsGa = new(3, true);
            
            _actionSystem.Perform(discardCardsGa);
        } 
    }
}