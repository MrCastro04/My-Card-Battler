using System.Collections.Generic;
using Modules.Content.Card.Scripts;
using Modules.Content.Deck;
using Modules.Core.Systems.Deck_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Deck_System_Installer
{
    public class DeckSystemInstaller : MonoInstaller
    {
        [SerializeField] private List<CardData> _startDeckData;
        [SerializeField] private DeckUnitsMono deckUnitsMonoPrefab;
        [SerializeField] private Transform _deckTransform;
        
        public override void InstallBindings()
        {
            BindDeckMono();

            BindDeckSystem();
        }

        private void BindDeckMono()
        {
            DeckUnitsMono deckUnitsMonoInstance = Container
                .InstantiatePrefabForComponent<DeckUnitsMono>(deckUnitsMonoPrefab,_deckTransform.position,Quaternion.identity, gameObject.transform);

            Container
                .BindInterfacesAndSelfTo<DeckUnitsMono>()
                .FromInstance(deckUnitsMonoInstance)
                .AsSingle();
        }

        private void BindDeckSystem()
        {
            Container
                .BindInterfacesAndSelfTo<DeckSystem>()
                .AsSingle()
                .WithArguments(_startDeckData);
        }
    }
}