using UnityEngine;
using Zenject;

namespace Modules.Content.Hand
{
    public class HandInstaller : MonoInstaller
    {
        [SerializeField] private HandView _hand;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<HandView>()
                .FromInstance(_hand)
                .AsSingle()
                .NonLazy() ;
        }
    }
}