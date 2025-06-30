using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Discard_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Draw_Card_System;
using Modules.Core.Systems.Card_System.Sub_Systems.Highlight_Card_System;
using Modules.Core.Systems.Deck_System;
using Modules.Core.Systems.Discard_Pile_System;
using Modules.Core.Systems.Hand_System;
using Modules.Core.Systems.Test_System;
using Modules.Core.Utils.Mono_Destroyer;
using Modules.Core.Utils.Mouse_Util;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Core.Zenject.System_Installer
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private TestSystem _testSystem;
        [SerializeField] private ActionSystem _actionSystemPrefab;
        [SerializeField] private float _updateCardsInHandDuration;
        [SerializeField] private int _handSize;
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private Vector3 _handPosition;
        [SerializeField] private Vector3 _discardPilePosition;
        [SerializeField] private List<CardData> _startDeckData;
        [SerializeField] private CardView _highlightCardViewPrefab;
        [SerializeField] private MonoDestroyer _monoDestroyerPrefab;

        public override void InstallBindings()
        {
            BindMonoDestroyer();

            BindActionSystem();

            BindHandSystem();

            BindDeckSystem();

            BindDiscardPileSystem();

            BindSubCardSystems();

            BindCardSystem();

            BindTestSystem();
        }

        private void BindMonoDestroyer()
        {
            var monoDestroyerInstance = Container
                .InstantiatePrefabForComponent<MonoDestroyer>(_monoDestroyerPrefab);

            Container
                .Bind<MonoDestroyer>()
                .FromInstance(monoDestroyerInstance)
                .AsCached()
                .NonLazy();
        }

        private void BindActionSystem()
        {
            Container
                .Bind<ActionSystem>()
                .FromInstance(_actionSystemPrefab)
                .AsSingle()
                .NonLazy();
        }

        private void BindDeckSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DeckSystem>()
                .AsSingle()
                .WithArguments(_startDeckData)
                .NonLazy();
        }

        private void BindDiscardPileSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DiscardPileSystem>()
                .AsSingle()
                .WithArguments(_discardPilePosition)
                .NonLazy();
        }

        private void BindHandSystem()
        {
            Container
                .BindInterfacesAndSelfTo<HandSystem>()
                .AsSingle()
                .WithArguments(_updateCardsInHandDuration, _handPosition, _handSize, _splineContainer)
                .NonLazy();
        }

        private void BindSubCardSystems()
        {
            Container
                .BindInterfacesAndSelfTo<DrawCardSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<DiscardCardSystem>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<HighlightCardSystem>()
                .AsSingle()
                .WithArguments(_highlightCardViewPrefab)
                .NonLazy();

            Container
                .Bind<MouseUtil>()
                .AsSingle()
                .NonLazy();

            MouseUtil mouseUtilInstance = Container.Resolve<MouseUtil>();

            Container
                .BindInterfacesAndSelfTo<CardInteractions>()
                .AsSingle()
                .WithArguments(mouseUtilInstance)
                .NonLazy();
        }

        private void BindCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<CardSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindTestSystem()
        {
            TestSystem testSystemInstance = Container
                .InstantiatePrefabForComponent<TestSystem>(_testSystem);

            Container
                .BindInterfacesAndSelfTo<TestSystem>()
                .FromInstance(testSystemInstance)
                .AsSingle();
        }
    }
}