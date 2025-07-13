using Zenject;

namespace Modules.New
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