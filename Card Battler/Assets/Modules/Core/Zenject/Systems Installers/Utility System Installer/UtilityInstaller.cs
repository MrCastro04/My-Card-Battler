using Modules.Core.Utils.Coroutine_Runner;
using Modules.Core.Utils.Mono_Destroyer;
using Modules.Core.Utils.Mouse_Util;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Utility_System_Installer
{
    public class UtilityInstaller : MonoInstaller
    {
        [SerializeField] private MonoDestroyer _monoDestroyerPrefab;
        [SerializeField] private CoroutineRunner _coroutineRunnerPrefab;
        
        public override void InstallBindings()
        {
            Container
                .Bind<ColliderActivator>()
                .FromNew()
                .AsSingle();
            
            BindCoroutineRunner();

            BindMonoDestroyer();

            BindMouseUtil();
        }

        private void BindCoroutineRunner()
        {
            CoroutineRunner coroutineRunnerInstance = Container
                .InstantiatePrefabForComponent<CoroutineRunner>(_coroutineRunnerPrefab, transform.position, Quaternion.identity,
                    gameObject.transform);

            Container
                .BindInterfacesAndSelfTo<CoroutineRunner>()
                .FromInstance(coroutineRunnerInstance)
                .AsSingle();
        }

        private void BindMonoDestroyer()
        {
            MonoDestroyer monoDestroyerInstance = Container
                .InstantiatePrefabForComponent<MonoDestroyer>(_monoDestroyerPrefab, transform.position, Quaternion.identity, gameObject.transform );

            Container
                .Bind<MonoDestroyer>()
                .FromInstance(monoDestroyerInstance)
                .AsSingle();
        }

        private void BindMouseUtil()
        {
            Container
                .Bind<MouseUtil>()
                .AsSingle();
        }
    }
}