using Modules.Content.Card.Types;
using UnityEngine;

namespace Modules.Content.Card.Scripts
{
    [CreateAssetMenu(menuName = "Data/Card")]
    public class CardData : ScriptableObject
    {
        [field: SerializeField] public int ManaAmount { get; private set; }
        [field: SerializeField] public int AttackAmount { get; private set; }
        [field: SerializeField] public int HealthAmount { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public CardTypes CardType { get; private set; }
    }
}