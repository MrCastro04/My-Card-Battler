using Modules.Core.Systems.Mana_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Mana_System_Installer
{
    public class ManaSystemInstaller : MonoInstaller
    {
        [SerializeField] private int _maxMana;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<ManaSystem>()
                .AsSingle()
                .WithArguments(_maxMana);
        }
    }
}