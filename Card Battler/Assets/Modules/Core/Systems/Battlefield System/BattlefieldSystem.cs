using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Modules.Content.Card.Scripts;
using Modules.Content.Card.Scripts.Data;
using Modules.Core.Factories.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Game_Actions.Unit_Enters_The_Battlefield_GA;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Base_Slot;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Enemy_Slot_Play_Unit_Mono;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Player_Slot_Play_Unit_Mono;
using Modules.Core.Utils.Coroutine_Runner;
using UnityEngine;
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
        private readonly ICardViewFactory _cardViewFactory;
        private readonly CardData _cardData;
        private readonly CoroutineRunner _coroutineRunner;
        
        public PlayerSlotPlayUnitMono[] PlayerSlots => _playerSlots;
        public EnemySlotPlayUnitMono[] EnemySlots => _enemySlots;

        [Inject]
        public BattlefieldSystem(
              ActionSystem actionSystem
            , PlayerSlotPlayUnitMono[] playerSlots
            , EnemySlotPlayUnitMono[] enemySlots
            , ICardInteractions cardInteractions
            , ICardViewFactory cardViewFactory
            , CardData cardData
            , CoroutineRunner coroutineRunner )
        {
            _actionSystem = actionSystem;

            _playerSlots = playerSlots;

            _enemySlots = enemySlots;

            _cardInteractions = cardInteractions;

            _cardViewFactory = cardViewFactory;

            _cardData = cardData;

            _coroutineRunner = coroutineRunner;

            _allBattlefieldSlots = new();
        }

        public void Initialize()
        {
            _actionSystem.AttachPerformer<UnitEnterTheBattlefieldGA>(UnitEnterTheBattlefieldPerformer);
         
            _allBattlefieldSlots.AddRange(_enemySlots);
            _allBattlefieldSlots.AddRange(_playerSlots);
            
           _coroutineRunner.Run(FillEnemySlots()); 
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

        private IEnumerator FillEnemySlots()
        {
            foreach (var enemySlot in _enemySlots)
            {
                CardView cardViewInstance = _cardViewFactory.Create(new(_cardData), enemySlot.transform.position);

                UnitEnterTheBattlefieldGA unitEnterTheBattlefieldGa = new(cardViewInstance, enemySlot);
        
                _actionSystem.Perform(unitEnterTheBattlefieldGa);

                yield return new WaitUntil(() => _actionSystem.IsPerforming == false);
            }
        }
        
        
        private IEnumerator UnitEnterTheBattlefieldPerformer(UnitEnterTheBattlefieldGA unitEnterTheBattlefieldGa)
        {
            var unit = unitEnterTheBattlefieldGa.Unit;
            var slot = unitEnterTheBattlefieldGa.Slot;

            var selectedSlot = _allBattlefieldSlots.FirstOrDefault(x => x == slot && !x.IsOccupied);

            if (selectedSlot == default)
            {
                yield break;
            }

            selectedSlot.SetOcupied(unit);
            selectedSlot.gameObject.SetActive(true);

            yield return null;
        }
        
        private void ShowAllEmptySlots()
        {
            foreach (var slot in _playerSlots.Where(x => !x.IsOccupied))
            {
                slot.gameObject.SetActive(true);
            }
        }

        private void HideAllEmptySlots()
        {
            foreach (var slot in _playerSlots.Where(x => !x.IsOccupied))
            {
                slot.gameObject.SetActive(false);
            }
        }
    }
}