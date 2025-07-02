using Modules.Core.Systems.Hand_System;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Hand_System_Installer
{
    public class HandSystemInstaller : MonoInstaller
    {
        [SerializeField] private float _updateCardsInHandDuration;
        [SerializeField] private int _handSize;
        [SerializeField] private Transform _handTransform;
        [SerializeField] private SplineContainer _splineContainer;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<HandSystem>()
                .AsSingle()
                .WithArguments(_updateCardsInHandDuration, _handTransform.position, _handSize, _splineContainer)
                .NonLazy();
        }
    }
}