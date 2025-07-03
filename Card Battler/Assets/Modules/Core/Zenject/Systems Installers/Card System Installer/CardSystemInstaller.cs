using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Discard_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Draw_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Highlight_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Play_Card_System;
using Modules.Core.Utils.Mouse_Util;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Card_System_Installer
{
    public class CardSystemInstaller : MonoInstaller
    {
        [SerializeField] private CardView _highlightCardViewPrefab;
        
        public override void InstallBindings()
        {
            BindPlayCardSystem();
            
            BindDrawCardSystem();

            BindDiscardCardSystem();

            BindHighlightCardSystem();
            
            BindCardInteractions();

            BindCardSystem();
        }

        private void BindPlayCardSystem()
        {
            Container.BindInterfacesAndSelfTo<PlayCardSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<CardSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindCardInteractions()
        {
            MouseUtil mouseUtilInstance = Container.Resolve<MouseUtil>();

            Container
                .BindInterfacesAndSelfTo<CardInteractions>()
                .AsSingle()
                .WithArguments(mouseUtilInstance)
                .NonLazy();
        }

        private void BindHighlightCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<HighlightCardSystem>()
                .AsSingle()
                .WithArguments(_highlightCardViewPrefab)
                .NonLazy();
        }

        private void BindDiscardCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DiscardCardSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindDrawCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DrawCardSystem>()
                .AsSingle()
                .NonLazy();
        }
    }
}