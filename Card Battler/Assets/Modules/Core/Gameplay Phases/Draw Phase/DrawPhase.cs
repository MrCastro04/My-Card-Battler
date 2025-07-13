using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Game_Actions;
using Modules.Core.Game_Actions.Draw_Cards_GA;
using Modules.Core.Gameplay_Phases.Base_Phase;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Phase_System;

namespace Modules.Core.Gameplay_Phases.Draw_Phase
{
    public class DrawPhase : BasePhase
    {
        public DrawPhase(ActionSystem actionSystem) : base(actionSystem) { }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            DrawCardsGA drawCardsGa = new(activeTurnOwner.DrawCardsAmountInDrawPhase, activeTurnOwner.Deck);
            
            _actionSystem.Perform(drawCardsGa);

            yield return base.Enter(activeTurnOwner, phaseSystem);
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            yield return null;
        }
    }
}