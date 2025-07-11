using System.Collections;
using Modules.Content.Player_Enemy;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Phase_System;
using UnityEngine;

namespace Modules.Core.Gameplay_Phases
{
    public class DrawPhase : BasePhase
    {
        public DrawPhase(ActionSystem actionSystem) : base(actionSystem) { }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            DrawCardsGA drawCardsGa = new(activeTurnOwner.DrawCardsAmountInDrawPhase, activeTurnOwner.Deck);
            
            _actionSystem.Perform(drawCardsGa);

            yield return Exit(activeTurnOwner);
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            yield return null;
        }
    }
}