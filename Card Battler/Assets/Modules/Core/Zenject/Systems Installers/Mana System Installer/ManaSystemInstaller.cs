using Modules.Core.Systems.Mana_System;
using Modules.Core.UI.Views.Mana_View;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Mana_System_Installer
{
    public class ManaSystemInstaller : MonoInstaller
    {
        [SerializeField] private int _maxMana;
        [SerializeField] private ManaView _manaViewPrefab;
        [SerializeField] private Transform _manaViewTransform;
        
        public override void InstallBindings()
        {
            BindManaView();
            
            BindManaSystem();
        }

        private void BindManaView()
        {
            ManaView manaViewInstance = Container
                .InstantiatePrefabForComponent<ManaView>(_manaViewPrefab, _manaViewTransform.position, _manaViewTransform.rotation, gameObject.transform);

            Container
                .BindInterfacesAndSelfTo<ManaView>()
                .FromInstance(manaViewInstance)
                .AsSingle();
        }

        private void BindManaSystem()
        {
            Container
                .BindInterfacesAndSelfTo<ManaSystem>()
                .AsSingle()
                .WithArguments(_maxMana);
        }
    }
}