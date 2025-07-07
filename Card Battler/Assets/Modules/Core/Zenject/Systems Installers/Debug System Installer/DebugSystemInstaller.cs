using Modules.Core.Systems.Debug_System;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Debug_System_Installer
{
    public class DebugSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<DebugSystem>()
                .AsSingle();
        }
    }
}