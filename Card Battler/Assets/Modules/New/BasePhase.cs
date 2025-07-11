using System;
using System.Collections;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    [Serializable]
    public abstract class BasePhase
    {
        protected ActionSystem _actionSystem;
        
        [Inject]
        public BasePhase(ActionSystem actionSystem)
        {
            _actionSystem = actionSystem;
        }
        
        public abstract IEnumerator Exit(ITurnOwner activeTurnOwner);
        public abstract IEnumerator Enter(ITurnOwner activeTurnOwner);
    }
}