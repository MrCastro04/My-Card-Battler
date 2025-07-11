using System;
using System.Collections;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;

namespace Modules.New
{
    public class DrawPhase : BasePhase
    {
        public DrawPhase(ActionSystem actionSystem) : base(actionSystem) { }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner)
        {
            DrawCardsGA drawCardsGa = new(activeTurnOwner.DrawCardsAmountInDrawPhase, activeTurnOwner.Deck);
            
            _actionSystem.Perform(drawCardsGa);

            yield return Exit(activeTurnOwner);
        }

        public override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            Debug.Log("Draw Phase End");
            yield return null;
        }
    }
}