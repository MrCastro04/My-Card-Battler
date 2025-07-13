using System;
using System.Collections;
using Modules.Content.Card.Scripts.Data;
using Modules.Content.Card.Scripts.Unit_Behaviour;
using Modules.Core.Game_Actions.Deal_Damage_Unit_GA;
using Modules.Core.Game_Actions.Destroy_Unit_GA;
using Modules.Core.Systems.Action_System.Scripts;
using Zenject;

namespace Modules.Core.Systems.Deal_Damage_Unit_System
{
    public class DealDamageUnitSystem : IInitializable, IDisposable
    {
        private readonly ActionSystem _actionSystem;

        public DealDamageUnitSystem(ActionSystem actionSystem)
        {
            _actionSystem = actionSystem;
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<DealDamageUnitGA>(DealDamagePerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<DealDamageUnitGA>();
        }

        private IEnumerator DealDamagePerformer(DealDamageUnitGA dealDamageUnitGa)
        {
            foreach (var target in dealDamageUnitGa.Targets)
            {
                UnitBehavior unitBehavior = (target.CardModel.CardData as UnitCardData)?.UnitBehavior;

                if (unitBehavior == null)
                    continue;

                unitBehavior.GetDamage(dealDamageUnitGa.AttackerDamage);

                if (unitBehavior.IsUnitDead())
                {
                    DestroyUnitGA destroyUnitGa = new(target);
                    
                    _actionSystem.AddReaction(destroyUnitGa);
                }
                
                yield return null;
            }
        }
    }
}