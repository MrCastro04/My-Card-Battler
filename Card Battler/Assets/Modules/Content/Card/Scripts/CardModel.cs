using Modules.New;
using UnityEngine;

namespace Modules.Content.Card.Scripts
{
    public class CardModel
    {
        public readonly BaseCardData BaseBaseCardData;
        
        private readonly int _healthAmount;
        private readonly int _damageAmount;
        private readonly CardType _cardType;
        
        public int ManaAmount => BaseBaseCardData.ManaAmount;
        public int HealthAmount => _healthAmount;
        public int DamageAmount => _damageAmount;
        public string Name => BaseBaseCardData.Name;
        public Sprite Image => BaseBaseCardData.Image;
        public CardType CardType => _cardType;

        public CardModel(BaseCardData baseBaseCardData)
        {
            if (baseBaseCardData is UnitCardData unitCardData)
            {
                _healthAmount = unitCardData.HealthAmount;

                _damageAmount = unitCardData.DamageAmount;

                _cardType = unitCardData.CardType;
                
                BaseBaseCardData = baseBaseCardData;
            }
            
            else if (baseBaseCardData is SpellCardData spellCardData)
            {
                BaseBaseCardData = baseBaseCardData;

                _healthAmount = 0;

                _damageAmount = 0;

                _cardType = spellCardData.CardType;
            }
        }
    }
}
