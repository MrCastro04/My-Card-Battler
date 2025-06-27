using Modules.Core.Systems.Hand_System;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Content.Hand.Scripts.Installer
{
    public class HandInstaller : MonoInstaller
    {
        [SerializeField] private int _maxHandSize;
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private Vector3 _handPosition;
        
        public override void InstallBindings()
        {
            BindHand();
        }

        private void BindHand()
        {
            Container
                .BindInterfacesAndSelfTo<HandSystem>()
                .AsSingle()
                .WithArguments(_maxHandSize,_splineContainer,_handPosition)
                .NonLazy();
        }
    }
}