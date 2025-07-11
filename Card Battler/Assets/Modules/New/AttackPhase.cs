using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Gameplay_Phases;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.Core.Systems.Phase_System;

namespace Modules.New
{
    public class AttackPhase : BasePhase
    {
        private readonly BattlefieldSystem _battlefieldSystem;
        
        public AttackPhase(ActionSystem actionSystem, BattlefieldSystem battlefieldSystem) : base(actionSystem)
        {
            _battlefieldSystem = battlefieldSystem;
        }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            yield return null;
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            yield return null;
        }
    }
}