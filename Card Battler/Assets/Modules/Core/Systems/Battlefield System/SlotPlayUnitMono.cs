using Modules.Content.Card.Scripts;
using Modules.Core.Utils.Collider_Activator;
using UnityEngine;
using Zenject;

namespace Modules.Core.Systems.Battlefield_System
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class SlotPlayUnitMono : MonoBehaviour
    {
        [SerializeField] protected SpriteRenderer _spriteRenderer;

        protected ColliderActivator _colliderActivator;

        public bool IsOccupied { get; private set; } = false;
        public CardView CardViewUnit { get; private set; } = null;

        [Inject]
        protected virtual void Construct(ColliderActivator colliderActivator)
        {
            _colliderActivator = colliderActivator;
        }

        public void SetOcupied(CardView cardViewUnit)
        {
            CardViewUnit = cardViewUnit;

            IsOccupied = true;

            _spriteRenderer.gameObject.SetActive(false);
            
            _colliderActivator.Disable(CardViewUnit.gameObject.GetComponent<Collider>());

            CardViewUnit.transform.SetParent(gameObject.transform);

            CardViewUnit.transform.localPosition = Vector3.zero;
        }

        public void SetUnocupied()
        {
            Destroy(CardViewUnit);

            CardViewUnit = null;

            IsOccupied = false;
            
            _colliderActivator.Actived(CardViewUnit?.gameObject.GetComponent<Collider>());

            _spriteRenderer.gameObject.SetActive(true);
        }
    }
}