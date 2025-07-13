using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.Core.Game_Actions.Deal_Damage_Unit_GA
{
    public class DealDamageUnitGA : GameAction
    {
        public readonly int AttackerDamage;
        public readonly List<CardView> Targets;
        
        public DealDamageUnitGA(int attackerDamage, List<CardView> targets)
        {
            AttackerDamage = attackerDamage;
            Targets = targets; 
        }
    }
}