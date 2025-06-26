using UnityEngine;
using Zenject;

namespace Modules.Core.Factories
{
    public class FactoriesInstaller : MonoInstaller
    {
        [SerializeField] private CardViewFactory _cardViewFactory;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesTo<CardViewFactory>()
                .FromInstance(_cardViewFactory)
                .AsSingle()
                .NonLazy();
        }
    }
}