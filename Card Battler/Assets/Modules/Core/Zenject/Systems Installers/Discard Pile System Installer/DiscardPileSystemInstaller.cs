using Modules.Core.Systems.Deck_System;
using Modules.Core.Systems.Discard_Pile_System;
using UnityEngine;
using Zenject;

namespace Modules.Core.Zenject.Systems_Installers.Discard_Pile_System_Installer
{
    public class DiscardPileSystemInstaller : MonoInstaller
    {
        [SerializeField] private float _downOffsetFromDeck;
        
        public override void InstallBindings()
        {
            DeckSystem deckSystem = Container.Resolve<DeckSystem>();

            Vector3 deckPosition = deckSystem.Position;
            
            Vector3 discardPilePosition = new Vector3(deckPosition.x,deckPosition.y + _downOffsetFromDeck, deckPosition.z );
            
            Container
                .BindInterfacesAndSelfTo<DiscardPileSystem>()
                .AsSingle()
                .WithArguments(discardPilePosition);
        }
    }
}