using Modules.Core.Systems.Turn_System;
using Modules.New;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Turn_System_Installer
{
    public class TurnSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TurnSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}