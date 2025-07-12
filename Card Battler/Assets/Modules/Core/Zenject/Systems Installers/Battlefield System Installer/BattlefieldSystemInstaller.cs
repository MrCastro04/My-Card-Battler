using Modules.Core.Systems.Battlefield_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Battlefield_System_Installer
{
    public class BattlefieldSystemInstaller : MonoInstaller
    {
        [SerializeField] private EnemySlotPlayUnitMono[] _enemySlots;
        [SerializeField] private PlayerSlotPlayUnitMono[] _playerSlots;

        public override void InstallBindings()
        {
            foreach (var slot in _enemySlots)
            {
                slot.gameObject.SetActive(false);
            }

            foreach (var slot in _playerSlots)
            {
                slot.gameObject.SetActive(false);
            }

            Container
                .BindInterfacesAndSelfTo<BattlefieldSystem>()
                .AsSingle()
                .WithArguments(_playerSlots, _enemySlots);
        }
    }
}