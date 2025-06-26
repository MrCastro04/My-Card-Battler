using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Content.Hand
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
            HandView newHand = new(_maxHandSize, _splineContainer, _handPosition);

            Container
                .BindInterfacesAndSelfTo<HandView>()
                .FromInstance(newHand)
                .AsSingle()
                .NonLazy();
        }
    }
}