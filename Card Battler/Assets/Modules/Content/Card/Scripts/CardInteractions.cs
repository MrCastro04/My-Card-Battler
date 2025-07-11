using Modules.Core.Gameplay_Phases;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Utils.Mouse_Util;
using Modules.New;

namespace Modules.Content.Card.Scripts
{
    public class CardInteractions : ICardInteractions
    {
        private readonly ActionSystem _actionSystem;
        private readonly CastPhase _castPhase;
        private readonly IManaSystem _manaSystem;
        
        public MouseUtil MouseUtil { get; }
        public bool IsDragging { get; private set; } = false;

        public CardInteractions(
            ActionSystem actionSystem,
            MouseUtil mouseUtil,
            CastPhase castPhase,
            IManaSystem manaSystem)
        {
            _actionSystem = actionSystem;
            
            MouseUtil = mouseUtil;

            _castPhase = castPhase;

            _manaSystem = manaSystem;
        }

        public bool CanPlayCard(int manaAmount)
        {
            if (_castPhase.CanPlayCards && _manaSystem.IsManaEnough(manaAmount))
                return true;

            return false;
        }

        public bool CanHover()
        {
            if (IsDragging)
                return false;

            return true;
        }

        public bool CanInteract()
        {
            if (_actionSystem.IsPerforming || _castPhase.CanPlayCards == false)
                return false;

            return true;
        }

        public void SetDragStatus(bool status) => IsDragging = status;
    }
}