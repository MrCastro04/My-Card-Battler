using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class ActionSystemInstaller : MonoInstaller
    {
        [SerializeField] private ActionSystem _actionSystemPrefab;
        
        public override void InstallBindings()
        {
            ActionSystem actionSystemInstance = Container
                .InstantiatePrefabForComponent<ActionSystem>(_actionSystemPrefab, transform.position, Quaternion.identity, gameObject.transform);

            Container
                .Bind<ActionSystem>()
                .FromInstance(actionSystemInstance)
                .AsSingle()
                .NonLazy();
        }
    }
}