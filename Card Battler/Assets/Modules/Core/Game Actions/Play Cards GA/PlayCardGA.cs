using Modules.Content.Card.Scripts;
using Modules.Core.Systems.Action_System.Scripts;
using UnityEngine;

namespace Modules.Core.Game_Actions.Play_Cards_GA
{
    public class PlayCardGA : GameAction
    {
        public readonly CardView PlayedCardView;
        public readonly RaycastHit HitInfo;

        public PlayCardGA(CardView playedCardView, RaycastHit hitInfo)
        {
            PlayedCardView = playedCardView;
            HitInfo = hitInfo;
        }
    }
}