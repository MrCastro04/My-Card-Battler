using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Phase_System;
using UnityEngine;
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

        public virtual IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            yield return new WaitUntil(() => phaseSystem.IsNextPhaseRequested);

            yield return Exit(activeTurnOwner);
        }
        
        protected abstract IEnumerator Exit(ITurnOwner activeTurnOwner);
    }
}