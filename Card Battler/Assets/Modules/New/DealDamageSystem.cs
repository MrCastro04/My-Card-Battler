using System;
using System.Collections;
using Modules.Core.Systems.Action_System.Scripts;
using Zenject;

namespace Modules.New
{
    public class DealDamageSystem
    {
        private readonly ActionSystem _actionSystem;

        [Inject]
        public DealDamageSystem(ActionSystem actionSystem)
        {
            _actionSystem = actionSystem;
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<DealDamageGA>(DealDamagePerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<DealDamageGA>();
        }

        private IEnumerator DealDamagePerformer(DealDamageGA dealDamageGa)
        {
            foreach (var target in dealDamageGa.Targets)
            {
                UnitBehavior unitBehavior = (target.CardModel.CardData as UnitCardData)?.UnitBehavior;
                
                if(unitBehavior == null) 
                    yield break;
                
                unitBehavior.GetDamage(dealDamageGa.AttackerDamage);
            }
        }
    }
}
