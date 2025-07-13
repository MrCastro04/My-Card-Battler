using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Gameplay_Phases.Base_Phase;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Mana_System;
using Modules.Core.Systems.Phase_System;

namespace Modules.Core.Gameplay_Phases.Pre_Draw_Phase
{
    public class PreDrawPhase : BasePhase
    {
        private IManaSystem _manaSystem;

        public PreDrawPhase(ActionSystem actionSystem, IManaSystem manaSystem) : base(actionSystem)
        {
            _manaSystem = manaSystem;
        }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            _manaSystem.RefillMana();

            yield return Exit(activeTurnOwner);
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            yield return null;
        }
    }
}