using System.Collections;
using Modules.Core.Systems.Action_System.Scripts;
using Zenject;

namespace Modules.New
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