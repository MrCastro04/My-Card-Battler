using System;
using System.Collections;
using System.Linq;
using Modules.Content.Card.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Zenject;

namespace Modules.Core.Systems.Battlefield_System
{
    public class BattlefieldSystem : IInitializable, IDisposable, ITickable
    {
        private readonly SlotPlayUnitMono[] _slots;
        private readonly ActionSystem _actionSystem;
        private readonly ICardInteractions _cardInteractions;

        [Inject]
        public BattlefieldSystem(ActionSystem actionSystem, SlotPlayUnitMono[] slots,
            ICardInteractions cardInteractions)
        {
            _actionSystem = actionSystem;

            _slots = slots;

            _cardInteractions = cardInteractions;
        }

        public void Tick()
        {
            if (_cardInteractions.IsDragging)
            {
                ShowAllEmptySlots();
            }
            else
            {
                HideAllEmptySlots();
            }
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<UnitEnterTheBattlefieldGA>(UnitEnterTheBattlefieldPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<UnitEnterTheBattlefieldGA>();
        }

        private IEnumerator UnitEnterTheBattlefieldPerformer(UnitEnterTheBattlefieldGA unitEnterTheBattlefieldGa)
        {
            CardView unitEnteredTheBattlefield = unitEnterTheBattlefieldGa.Unit;

            SlotPlayUnitMono slotPlayUnitMono = unitEnterTheBattlefieldGa.Slot;

            SlotPlayUnitMono selectedSlot = _slots
                .FirstOrDefault(x => x == slotPlayUnitMono && x != x.IsOccupied);

            if(selectedSlot == default) 
                yield break;
            
            selectedSlot.SetOcupied(unitEnteredTheBattlefield);
            
            selectedSlot.gameObject.SetActive(true);

            yield return null;
        }

        private void ShowAllEmptySlots()
        {
            foreach (var slot in _slots.Where(x => x != x.IsOccupied))
            {
                slot.gameObject.SetActive(true);
            }
        }

        private void HideAllEmptySlots()
        {
            foreach (var slot in _slots.Where(x => x != x.IsOccupied))
            {
                slot.gameObject.SetActive(false);
            }
        }
    }
}