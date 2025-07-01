using Modules.Core.Utils.Mono_Destroyer;
using Modules.Core.Utils.Mouse_Util;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class UtilityInstaller : MonoInstaller
    {
        [SerializeField] private MonoDestroyer _monoDestroyerPrefab;
        
        public override void InstallBindings()
        {
            BindMonoDestroyer();

            BindMouseUtil();
        }

        private void BindMonoDestroyer()
        {
            MonoDestroyer monoDestroyerInstance = Container
                .InstantiatePrefabForComponent<MonoDestroyer>(_monoDestroyerPrefab, transform.position, Quaternion.identity, gameObject.transform );

            Container
                .Bind<MonoDestroyer>()
                .FromInstance(monoDestroyerInstance)
                .AsSingle()
                .NonLazy();
        }

        private void BindMouseUtil()
        {
            Container
                .Bind<MouseUtil>()
                .AsSingle()
                .NonLazy();
        }
    }
}