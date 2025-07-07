using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Action_System_Installer
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
                .AsSingle();
        }
    }
}