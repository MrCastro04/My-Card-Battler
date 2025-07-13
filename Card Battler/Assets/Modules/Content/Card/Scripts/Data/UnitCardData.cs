using System;
using Modules.Content.Card.Scripts.Unit_Behaviour;
using UnityEngine;

namespace Modules.Content.Card.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Card/Unit")]
    [Serializable]
    public class UnitCardData : CardData
    {
        public UnitBehavior UnitBehavior;
        
        [field: SerializeField] public int HealthAmount { get; private set; }
        [field: SerializeField] public int DamageAmount { get; private set; }
        
        public CardType CardType => CardType.Unit;
    }
}