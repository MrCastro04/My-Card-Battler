using Modules.Core.Systems.Test_System;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Test_System_Installer
{
    public class TestSystemInstaller : MonoInstaller
    {
        [SerializeField] private TestSystem _testSystem;
        
        public override void InstallBindings()
        {
            TestSystem testSystemInstance = Container
                .InstantiatePrefabForComponent<TestSystem>(_testSystem,transform.position, Quaternion.identity, gameObject.transform);

            Container
                .BindInterfacesAndSelfTo<TestSystem>()
                .FromInstance(testSystemInstance)
                .AsSingle();     
        }
    }
}