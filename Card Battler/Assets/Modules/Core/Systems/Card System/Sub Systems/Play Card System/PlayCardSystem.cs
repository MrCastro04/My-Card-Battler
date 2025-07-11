using System.Collections;
using Modules.Content.Card.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Systems.Battlefield_System;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Play_Card_System
{
    public class PlayCardSystem : IPlayCardSystem
    {
        private readonly IManaSystem _manaSystem;
        private readonly ActionSystem _actionSystem;
        private readonly CastPhase _castPhase;
        
        [Inject]
        public PlayCardSystem(IManaSystem manaSystem, ActionSystem actionSystem, CastPhase castPhase)
        {
            _manaSystem = manaSystem;

            _actionSystem = actionSystem;

            _castPhase = castPhase;
        }

        public IEnumerator PlayCardPerformer(PlayCardGA playCardGa)
        {
            if (_castPhase.CanPlayCards == false)
            {
                yield break;
            }
            
            yield return PlayCard(playCardGa.PlayedCardView, playCardGa.HitInfo);
        }

        private IEnumerator PlayCard(CardView playedCardView, RaycastHit hitInfo)
        {
            SlotPlayUnitMono slotPlayUnitMono = hitInfo.collider.GetComponent<SlotPlayUnitMono>();

            _manaSystem.SpendMana(playedCardView.CardModel.ManaAmount);

            switch (playedCardView.CardModel.CardType)
            {
                case CardType.Unit:
                    
                    UnitEnterTheBattlefieldGA unitEnterTheBattlefieldGa = new(playedCardView,slotPlayUnitMono);

                    _actionSystem.AddReaction(unitEnterTheBattlefieldGa);

                    break;

                case CardType.Spell:

                    yield return null;
                    break;
            }
        }
    }
}