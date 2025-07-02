using System.Collections;
using Modules.Content.Card.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.New;
using Zenject;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Play_Card_System
{
    public class PlayCardSystem : IPlayCardSystem
    {
        private readonly IManaSystem _manaSystem;
        private readonly ActionSystem _actionSystem;

        [Inject]
        public PlayCardSystem(IManaSystem manaSystem, ActionSystem actionSystem)
        {
            _manaSystem = manaSystem;

            _actionSystem = actionSystem;
        }

        public IEnumerator PlayCardPerformer(PlayCardGA playCardGa)
        {
            yield return PlayCard(playCardGa.PlayedCardView);
        }

        private IEnumerator PlayCard(CardView playedCardView)
        {
            _manaSystem.SpendMana(playedCardView.CardModel.ManaAmount);

            switch (playedCardView.CardModel.CardType)
            {
                case CardType.Unit:

                    DiscardCardsGA discardCardsGa = new(playedCardView);

                    _actionSystem.AddReaction(discardCardsGa);
                    break;

                case CardType.Spell:

                    yield return null;
                    break;
            }
        }
    }
}