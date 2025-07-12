using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;

namespace Modules.New
{
    public class DealDamageGA : GameAction
    {
        public readonly CardView Attacker;
        public readonly List<CardView> Targets;

        public DealDamageGA(CardView attacker, List<CardView> targets)
        {
            Attacker = attacker;
            Targets = targets;
        }
    }
}