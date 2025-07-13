using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Gameplay_Phases.Base_Phase;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Phase_System;

namespace Modules.Core.Gameplay_Phases.Cast_Phase
{
    public class CastPhase : BasePhase
    {
        public bool CanPlayCards { get; private set; } = false;

        public CastPhase(ActionSystem actionSystem) : base(actionSystem) {}

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            CanPlayCards = true;

            yield return base.Enter(activeTurnOwner, phaseSystem);
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            CanPlayCards = false;

            yield return null;
        }
    }
}