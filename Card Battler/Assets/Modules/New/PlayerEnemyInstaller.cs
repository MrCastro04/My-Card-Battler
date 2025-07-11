using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class PlayerEnemyInstaller : MonoInstaller
    {
        [SerializeField] private int _drawCardsInDrawPhase;
        
        public override void InstallBindings()
        {
            Container
                .BindInterfacesAndSelfTo<Player>()
                .AsSingle()
                .WithArguments( _drawCardsInDrawPhase);
        }
    }
}