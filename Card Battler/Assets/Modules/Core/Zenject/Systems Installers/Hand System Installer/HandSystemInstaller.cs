using Modules.Core.Systems.Hand_System;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.New
{
    public class HandSystemInstaller : MonoInstaller
    {
        [SerializeField] private float _updateCardsInHandDuration;
        [SerializeField] private int _handSize;
        [SerializeField] private Vector3 _handPosition;
        [SerializeField] private SplineContainer _splineContainer;
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<HandSystem>()
                .AsSingle()
                .WithArguments(_updateCardsInHandDuration, _handPosition, _handSize, _splineContainer)
                .NonLazy();
        }
    }
}