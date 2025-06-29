using Modules.Core.Factories.Scripts;
using Zenject;

namespace Modules.Core.Context.Factories_Installer
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
        }
    }
}