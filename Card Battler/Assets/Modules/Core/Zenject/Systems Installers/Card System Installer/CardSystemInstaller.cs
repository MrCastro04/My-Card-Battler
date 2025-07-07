using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Discard_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Draw_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Highlight_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Play_Card_System;
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
                .AsSingle();
        }

        private void BindCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<CardSystem>()
                .AsSingle();
        }

        private void BindCardInteractions()
        {
            Container
                .BindInterfacesAndSelfTo<CardInteractions>()
                .AsSingle();
        }

        private void BindHighlightCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<HighlightCardSystem>()
                .AsSingle()
                .WithArguments(_highlightCardViewPrefab);
        }

        private void BindDiscardCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DiscardCardSystem>()
                .AsSingle();
        }

        private void BindDrawCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DrawCardSystem>()
                .AsSingle();
        }
    }
}