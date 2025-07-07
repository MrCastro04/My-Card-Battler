using Modules.Core.Systems.Battlefield_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Battle_System_Installer
{
    public class BattlefieldSystemInstaller : MonoInstaller
    {
       [SerializeField] private SlotPlayUnitMono[] _slots;
 
        public override void InstallBindings()
        {
            foreach (var slot in _slots)
            {
                slot.gameObject.SetActive(false);
            }
            
            Container
                .BindInterfacesAndSelfTo<BattlefieldSystem>()
                .AsSingle()
                .WithArguments(_slots);
        }
    }
}