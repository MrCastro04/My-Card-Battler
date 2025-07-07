using Modules.Content.Card.Scripts;
using Modules.New;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Battlefield_System
{
    [RequireComponent(typeof(BoxCollider))]
    public class SlotPlayUnitMono : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [SerializeField] private BoxCollider _boxCollider;

        private ColliderActivator _colliderActivator;

        public bool IsOccupied { get; private set; } = false;
        public CardView CardViewUnit { get; private set; } = null;

        [Inject]
        private void Construct(ColliderActivator colliderActivator)
        {
            _colliderActivator = colliderActivator;
        }

        public void SetOcupied(CardView cardViewUnit)
        {
            CardViewUnit = cardViewUnit;

            IsOccupied = true;

            _spriteRenderer.gameObject.SetActive(false);

            CardViewUnit.transform.SetParent(transform);

            CardViewUnit.transform.localPosition = Vector3.zero;

            _colliderActivator.Disable(_boxCollider);
        }

        public void SetUnocupied()
        {
            Destroy(CardViewUnit);

            CardViewUnit = null;

            IsOccupied = false;

            _spriteRenderer.gameObject.SetActive(true);

            _colliderActivator.Actived(_boxCollider);
        }
    }
}