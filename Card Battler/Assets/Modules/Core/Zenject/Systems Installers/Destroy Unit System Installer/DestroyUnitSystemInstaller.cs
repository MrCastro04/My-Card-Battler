using Modules.Core.Systems.Destroy_Unit_System;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Destroy_Unit_System_Installer
{
    public class DestroyUnitSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<DestroyUnitSystem>()
                .AsSingle();
        }
    }
}