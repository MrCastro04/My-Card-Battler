using Zenject;

namespace Modules.Core.Factories.Scripts.Installer
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
                .BindInterfacesTo<CardViewFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}