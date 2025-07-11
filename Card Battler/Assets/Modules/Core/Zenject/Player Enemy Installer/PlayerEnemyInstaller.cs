using Modules.Content.Player_Enemy;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Player_Enemy_Installer
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