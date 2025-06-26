using Zenject;

namespace Modules.Core.Factories
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<CardViewFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}