using System.Collections.Generic;
using Modules.Content;
using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Deck_System;
using UnityEngine;
using Zenject;

namespace Modules.New
{
    public class DeckSystemInstaller : MonoInstaller
    {
        [SerializeField] private List<CardData> _startDeckData;
        [SerializeField] private DeckMono _deckMonoPrefab;
        
        public override void InstallBindings()
        {
            BindDeckMono();

            BindDeckSystem();
        }

        private void BindDeckSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DeckSystem>()
                .AsSingle()
                .WithArguments(_startDeckData)
                .NonLazy();
        }

        private void BindDeckMono()
        {
            DeckMono deckMonoInstance = Container
                .InstantiatePrefabForComponent<DeckMono>(_deckMonoPrefab);

            Container
                .BindInterfacesAndSelfTo<DeckMono>()
                .FromInstance(deckMonoInstance)
                .AsCached();
        }
    }
}