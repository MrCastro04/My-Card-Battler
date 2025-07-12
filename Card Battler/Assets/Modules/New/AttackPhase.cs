using System.Collections;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using Modules.Content.Player_Enemy;
using Modules.Core.Gameplay_Phases;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.Core.Systems.Phase_System;
using UnityEngine;

namespace Modules.New
{
    public class AttackPhase : BasePhase
    {
        private readonly ActionSystem _actionSystem;
        private readonly BattlefieldSystem _battlefieldSystem;
        private readonly LayerMask _playZoneMask;
        
        public AttackPhase(ActionSystem actionSystem, BattlefieldSystem battlefieldSystem,LayerMask playZoneMask) : base(actionSystem)
        {
            _actionSystem = actionSystem;
            
            _battlefieldSystem = battlefieldSystem;

            _playZoneMask = playZoneMask;
        }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            foreach (var playerSlot in _battlefieldSystem.PlayerSlots)
            {
                CardView playerUnit = playerSlot.CardViewUnit;
                
                playerUnit.transform.DOMoveY(5, 0.15f);

                if (Physics.Raycast(playerUnit.transform.position, Vector3.up, out RaycastHit hitInfo, 10f, _playZoneMask)
                && hitInfo.collider != null)
                {
                    if (hitInfo.collider.TryGetComponent(out SlotPlayUnitMono enemySlot) && enemySlot.IsOccupied)
                    {
                        CardView enemyUnit = enemySlot.CardViewUnit;

                        DealDamageGA dealDamageGa = new(playerUnit, new() {enemyUnit});
                        
                        _actionSystem.AddReaction(dealDamageGa);
                    }
                }
                

                Tween tween = playerUnit.transform.DOMoveY(0, 0.1f);

                yield return tween.WaitForCompletion();
            }
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            yield return null;
        }
    }
}