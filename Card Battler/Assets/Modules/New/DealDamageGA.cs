using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.New
{
    public class DealDamageGA : GameAction
    {
        public readonly int AttackerDamage;
        public readonly List<CardView> Targets;
        
        public DealDamageGA(int attackerDamage, List<CardView> targets)
        {
            AttackerDamage = attackerDamage;
            Targets = targets; 
        }
    }
}