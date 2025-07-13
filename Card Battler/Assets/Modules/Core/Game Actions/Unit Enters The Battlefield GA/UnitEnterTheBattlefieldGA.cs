using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Base_Slot;

namespace Modules.Core.Game_Actions.Unit_Enters_The_Battlefield_GA
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