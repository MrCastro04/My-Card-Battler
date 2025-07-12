using System;
using UnityEngine;

namespace Modules.New
{
    [CreateAssetMenu(menuName = "Data/Card/Unit")]
    [Serializable]
    public class UnitCardData : BaseCardData
    {
        [field: SerializeField] public int HealthAmount { get; private set; }
        [field: SerializeField] public int DamageAmount { get; private set; }
        
        public CardType CardType => CardType.Unit;
    }
}