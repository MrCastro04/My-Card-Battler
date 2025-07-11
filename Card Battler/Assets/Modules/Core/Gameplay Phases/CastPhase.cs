using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Phase_System;
using UnityEngine;

namespace Modules.Core.Gameplay_Phases
{
    public class CastPhase : BasePhase
    {
        public bool CanPlayCards { get; private set; } = false;

        public CastPhase(ActionSystem actionSystem) : base(actionSystem) { }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            CanPlayCards = true;

            Debug.Log("Cast Phase Start");

            yield return base.Enter(activeTurnOwner, phaseSystem);
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            CanPlayCards = false;

            Debug.Log("Cast Phase End");

            yield return null;
        }
    }
}