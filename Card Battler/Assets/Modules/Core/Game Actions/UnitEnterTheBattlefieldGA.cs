using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.New;

namespace Modules.Core.Game_Actions
{
    public class UnitEnterTheBattlefieldGA : GameAction
    {
        public readonly CardView Unit;
        public readonly SlotPlayUnitMono Slot;

        public UnitEnterTheBattlefieldGA(CardView unit, SlotPlayUnitMono slot)
        {
            Unit = unit;
            Slot = slot;
        }
    }
}