using Modules.New;
using UnityEngine;

namespace Modules.Content.Card.Scripts
{
    public class CardModel
    {
        public readonly CardData CardData;

        public int ManaAmount => CardData.ManaAmount;
        public string Name => CardData.Name;
        public Sprite Image => CardData.Image;
        public CardType CardType => CardData.CardType;

        public CardModel(CardData cardData)
        {
            CardData = cardData;
        }
    }
}
