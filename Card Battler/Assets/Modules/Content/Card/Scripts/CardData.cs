using Modules.New;
using UnityEngine;

namespace Modules.Content.Card.Scripts
{
    [CreateAssetMenu(menuName = "Data/Card")]
    public class CardData : ScriptableObject
    {
        [field: SerializeField] public int ManaAmount { get; private set; }
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public Sprite Image { get; private set; }
        [field: SerializeField] public CardType CardType { get; private set; }

    }
}