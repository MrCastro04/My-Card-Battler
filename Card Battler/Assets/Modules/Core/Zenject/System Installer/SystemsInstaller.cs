using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Hand_System;
using Modules.Core.Systems.Test_System;
using Modules.New;
using Modules.New.Card_System;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Core.Context.System_Installer
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private TestSystem _testSystem;
        [SerializeField] private ActionSystem _actionSystemPrefab;
        [SerializeField] private int _handSize;
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private Vector3 _handPosition;
        [SerializeField] private List<CardData> _startDeckData;
        
        public override void InstallBindings()
        {
            BindActionSystem();

            BindDeckSystem();
            
            BindHandSystem();
            
            BindCardSystem();
            
            BindTestSystem();
        }

        private void BindCardSystem()
        {
            Container
                .BindInterfacesAndSelfTo<CardSystem>()
                .AsSingle()
                .NonLazy();
        }

        private void BindDeckSystem()
        {
            Container
                .Bind<DeckSystem>()
                .AsSingle()
                .WithArguments(_startDeckData)
                .NonLazy();
        }

        private void BindHandSystem()
        {
            Container
                .BindInterfacesAndSelfTo<HandSystem>()
                .AsSingle()
                .WithArguments(_handPosition, _handSize, _splineContainer)
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

        private void BindActionSystem()
        {
            Container
                .Bind<ActionSystem>()
                .FromInstance(_actionSystemPrefab)
                .AsSingle()
                .NonLazy();
        }
    }
}