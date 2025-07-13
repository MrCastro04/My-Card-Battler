using System;
using UnityEngine;

namespace Modules.New
{
    [CreateAssetMenu(menuName = "Data/Card/Spell")]
    [Serializable]
    public class SpellCardData : CardData
    {
        public CardType CardType => CardType.Spell;
    }
}