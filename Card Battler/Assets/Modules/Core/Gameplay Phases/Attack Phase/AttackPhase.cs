using System.Collections;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using Modules.Content.Card.Scripts.Data;
using Modules.Content.Card.Scripts.Unit_Behaviour;
using Modules.Content.Player_Enemy;
using Modules.Core.Game_Actions.Deal_Damage_Unit_GA;
using Modules.Core.Gameplay_Phases.Base_Phase;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Base_Slot;
using Modules.Core.Systems.Phase_System;
using UnityEngine;

namespace Modules.Core.Gameplay_Phases.Attack_Phase
{
    public class AttackPhase : BasePhase
    {
        private readonly ActionSystem _actionSystem;
        private readonly BattlefieldSystem _battlefieldSystem;
        private readonly LayerMask _playZoneMask;

        public AttackPhase(ActionSystem actionSystem, BattlefieldSystem battlefieldSystem, LayerMask playZoneMask) :
            base(actionSystem)
        {
            _actionSystem = actionSystem;

            _battlefieldSystem = battlefieldSystem;

            _playZoneMask = playZoneMask;
        }

        public override IEnumerator Enter(ITurnOwner activeTurnOwner, PhaseSystem phaseSystem)
        {
            yield return PlayerUnitsExecuteAttack();
            
            yield return base.Enter(activeTurnOwner, phaseSystem);
        }

        protected override IEnumerator Exit(ITurnOwner activeTurnOwner)
        {
            yield return null;
        }

        private IEnumerator PlayerUnitsExecuteAttack()
        {
            foreach (var playerSlot in _battlefieldSystem.PlayerSlots)
            {
                if (playerSlot == null || playerSlot.IsOccupied == false || playerSlot.CardViewUnit == null)
                    continue;

                CardView playerUnit = playerSlot.CardViewUnit;

                if (Physics.Raycast(playerUnit.transform.position, Vector3.up, out RaycastHit hitInfo, 10f, _playZoneMask)
                    && hitInfo.collider != null)
                {
                    if (hitInfo.collider.TryGetComponent(out SlotPlayUnitMono enemySlot) && enemySlot.IsOccupied)
                    {
                        CardView enemyUnit = enemySlot.CardViewUnit;

                        UnitBehavior unitBehavior = (playerUnit.CardModel.CardData as UnitCardData)?.UnitBehavior;

                        if (unitBehavior == null)
                            continue;

                        Tween moveToEnemyUnitTween = playerUnit.transform
                            .DOMoveY(Vector3.Distance(playerUnit.transform.position, enemyUnit.transform.position) / 2,
                                0.15f);

                        yield return moveToEnemyUnitTween.WaitForCompletion();

                        DealDamageUnitGA dealDamageUnitGa = new(unitBehavior.CurrentDamage, new() {enemyUnit});

                        _actionSystem.Perform(dealDamageUnitGa);

                        Tween returnInOwnSlotTween = playerUnit.transform.DOMove(playerSlot.transform.position, 0.1f);

                        yield return returnInOwnSlotTween.WaitForCompletion();
                    }
                }
            }
        }
    }
}