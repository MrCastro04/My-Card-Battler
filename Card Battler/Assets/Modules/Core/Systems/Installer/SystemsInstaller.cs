using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Installer
{
    public class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private ActionSystem _actionSystemPrefab;
        
        public override void InstallBindings()
        {
            BindActionSystem();
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