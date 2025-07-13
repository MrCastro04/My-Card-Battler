using Modules.Content.Card.Scripts.Data;
using Modules.Core.Systems.Battlefield_System;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Enemy_Slot_Play_Unit_Mono;
using Modules.Core.Systems.Battlefield_System.Battlefield_Slots_For_Units.Player_Slot_Play_Unit_Mono;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Battlefield_System_Installer
{
    public class BattlefieldSystemInstaller : MonoInstaller
    {
        [SerializeField] private EnemySlotPlayUnitMono[] _enemySlots;
        [SerializeField] private PlayerSlotPlayUnitMono[] _playerSlots;
        [SerializeField] private CardData _cardData;
        
        public override void InstallBindings()
        {
            // foreach (var slot in _enemySlots)
            // {
            //     slot.gameObject.SetActive(false);
            // }

            foreach (var slot in _playerSlots)
            {
                slot.gameObject.SetActive(false);
            }

            Container
                .BindInterfacesAndSelfTo<BattlefieldSystem>()
                .AsSingle()
                .WithArguments(_playerSlots, _enemySlots, _cardData);
        }
    }
}