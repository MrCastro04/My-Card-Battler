using Modules.Content.Card.Types;

namespace Modules.Content.Card.Scripts.Models
{
    public class CardModel
    {
        public readonly CardData CardData;

        public int ManaAmount => CardData.ManaAmount;
        public int AttackAmount => CardData.AttackAmount;
        public int HealthAmount => CardData.HealthAmount;
        public string Name => CardData.Name;
        public string Description => CardData.Description;
        public CardTypes CardType => CardData.CardType;

        public CardModel(CardData cardData)
        {
            CardData = cardData;
        }
    }
}
