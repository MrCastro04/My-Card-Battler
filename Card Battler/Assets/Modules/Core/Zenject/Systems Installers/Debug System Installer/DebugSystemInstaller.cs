using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Debug_System;
using Modules.Core.Systems.Deck_System;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Debug_System_Installer
{
    public class DebugSystemInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            ActionSystem actionSystemResolve = Container.Resolve<ActionSystem>();
            DeckSystem deckSystemResolve = Container.Resolve<DeckSystem>();
            
            Container
                .BindInterfacesAndSelfTo<DebugSystem>()
                .AsSingle()
                .WithArguments(actionSystemResolve,deckSystemResolve)
                .NonLazy();
        }
    }
}