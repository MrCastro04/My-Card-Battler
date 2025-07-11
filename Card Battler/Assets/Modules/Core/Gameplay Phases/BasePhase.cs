using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Systems.Action_System.Scripts;
using Zenject;

namespace Modules.Core.Gameplay_Phases
{
    public abstract class BasePhase
    {
        protected ActionSystem _actionSystem;
        
        [Inject]
        public BasePhase(ActionSystem actionSystem)
        {
            _actionSystem = actionSystem;
        }
        
        public abstract IEnumerator Enter(ITurnOwner activeTurnOwner);
    }
}