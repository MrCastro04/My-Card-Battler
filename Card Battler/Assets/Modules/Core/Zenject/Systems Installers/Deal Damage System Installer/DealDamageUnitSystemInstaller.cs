using Modules.Core.Systems.Deal_Damage_Unit_System;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Deal_Damage_System_Installer
{
    public class DealDamageUnitSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<DealDamageUnitSystem>()
                .AsSingle();
        }
    }
}