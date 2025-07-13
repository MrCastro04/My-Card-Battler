using Modules.Content.Card.Scripts.Data;
using UnityEngine;

namespace Modules.Content.Card.Scripts
{
    public class CardModel
    {
        public readonly CardData CardData;
        
        private readonly int _healthAmount;
        private readonly int _damageAmount;
        private readonly CardType _cardType;
        
        public int ManaAmount => CardData.ManaAmount;
        public int HealthAmount => _healthAmount;
        public int DamageAmount => _damageAmount;
        public string Name => CardData.Name;
        public Sprite Image => CardData.Image;
        public CardType CardType => _cardType;

        public CardModel(CardData cardData)
        {
            if (cardData is UnitCardData unitCardData)
            {
                _healthAmount = unitCardData.HealthAmount;

                _damageAmount = unitCardData.DamageAmount;

                _cardType = unitCardData.CardType;

                unitCardData.UnitBehavior = new(_healthAmount, _damageAmount);
                
                CardData = cardData;
            }
            
            else if (cardData is SpellCardData spellCardData)
            {
                CardData = cardData;

                _healthAmount = 0;

                _damageAmount = 0;

                _cardType = spellCardData.CardType;
            }
        }
    }
}
