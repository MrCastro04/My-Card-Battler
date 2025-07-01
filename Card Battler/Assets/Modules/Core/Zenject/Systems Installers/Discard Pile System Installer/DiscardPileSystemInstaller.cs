using Modules.Core.Systems.Discard_Pile_System;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class DiscardPileSystemInstaller : MonoInstaller
    {
        [SerializeField] private Vector3 _discardPilePosition;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<DiscardPileSystem>()
                .AsSingle()
                .WithArguments(_discardPilePosition)
                .NonLazy();
        }
    }
}