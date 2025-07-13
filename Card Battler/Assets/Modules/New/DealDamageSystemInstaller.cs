using Zenject;

namespace Modules.New
{
    public class DealDamageSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<DealDamageUnitSystem>()
                .AsSingle();
        }
    }
}