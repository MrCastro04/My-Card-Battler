using System;
using UnityEngine;

namespace Modules.Content.Card.Scripts.Data
{
    [CreateAssetMenu(menuName = "Data/Card/Spell")]
    [Serializable]
    public class SpellCardData : CardData
    {
        public CardType CardType => CardType.Spell;
    }
}