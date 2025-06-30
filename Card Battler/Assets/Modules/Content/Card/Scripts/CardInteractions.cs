using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Utils.Mouse_Util;

namespace Modules.Content.Card.Scripts
{
    public class CardInteractions : ICardInteractions
    {
        private readonly ActionSystem _actionSystem;
        
        public MouseUtil MouseUtil { get; }
        public bool IsDragging { get; private set; } = false;

        public CardInteractions(ActionSystem actionSystem, MouseUtil mouseUtil)
        {
            _actionSystem = actionSystem;
            
            MouseUtil = mouseUtil;
        }

        public bool CanHover()
        {
            if (IsDragging)
                return false;

            return true;
        }

        public bool CanInteract()
        {
            if (_actionSystem.IsPerforming)
                return false;

            return true;
        }

        public void SetDragStatus(bool status) => IsDragging = status;
    }
}