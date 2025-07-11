using Modules.Core.Factories.Scripts;
using Zenject;

namespace Modules.Core.Zenject.Factories_Installer
{
    public class FactoriesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindCardViewFactory();
        }

        private void BindCardViewFactory()
        {
            Container
                .BindInterfacesAndSelfTo<CardViewFactory>()
                .AsSingle()
                .NonLazy();

            CardViewFactory cardViewFactoryResolve = Container.Resolve<CardViewFactory>();
            
            cardViewFactoryResolve.Load();
        }
    }
}