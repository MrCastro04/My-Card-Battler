using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Modules.Content.Card.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Battlefield_System
{
    public class BattlefieldSystem : IInitializable, IDisposable, ITickable
    {
        private readonly List<SlotPlayUnitMono> _allBattlefieldSlots;
        private readonly PlayerSlotPlayUnitMono[] _playerSlots;
        private readonly EnemySlotPlayUnitMono[] _enemySlots;
        private readonly ActionSystem _actionSystem;
        private readonly ICardInteractions _cardInteractions;
        public PlayerSlotPlayUnitMono[] PlayerSlots => _playerSlots;
        public EnemySlotPlayUnitMono[] EnemySlots => _enemySlots;

        [Inject]
        public BattlefieldSystem(
            ActionSystem actionSystem,
            PlayerSlotPlayUnitMono[] playerSlots,
            EnemySlotPlayUnitMono[] enemySlots,
            ICardInteractions cardInteractions)
        {
            _actionSystem = actionSystem;

            _playerSlots = playerSlots;

            _enemySlots = enemySlots;

            _cardInteractions = cardInteractions;

            _allBattlefieldSlots = new();
        }

        public void Initialize()
        {
            _allBattlefieldSlots.AddRange(_enemySlots);
            _allBattlefieldSlots.AddRange(_playerSlots);

            _actionSystem.AttachPerformer<UnitEnterTheBattlefieldGA>(UnitEnterTheBattlefieldPerformer);
        }

        public void Dispose()
        {
            _actionSystem.DetachPerformer<UnitEnterTheBattlefieldGA>();
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

        private IEnumerator UnitEnterTheBattlefieldPerformer(UnitEnterTheBattlefieldGA unitEnterTheBattlefieldGa)
        {
            CardView unitEnteredTheBattlefield = unitEnterTheBattlefieldGa.Unit;

            SlotPlayUnitMono slotPlayUnitMono = unitEnterTheBattlefieldGa.Slot;

            SlotPlayUnitMono selectedSlot = _allBattlefieldSlots
                .FirstOrDefault(x => x == slotPlayUnitMono && x != x.IsOccupied);

            if (selectedSlot == default)
                yield break;

            selectedSlot.SetOcupied(unitEnteredTheBattlefield);

            selectedSlot.gameObject.SetActive(true);

            yield return null;
        }

        private void ShowAllEmptySlots()
        {
            foreach (var slot in _playerSlots.Where(x => x != x.IsOccupied))
            {
                slot.gameObject.SetActive(true);
            }
        }

        private void HideAllEmptySlots()
        {
            foreach (var slot in _playerSlots.Where(x => x != x.IsOccupied))
            {
                slot.gameObject.SetActive(false);
            }
        }
    }
}