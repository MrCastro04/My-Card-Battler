using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules
{
    public class TestSystem : MonoBehaviour
    {
        [SerializeField] private CardData _cardData;
        [SerializeField] private CardView _cardView;

        private void Awake()
        {
            _cardView.Setup(new(_cardData)); 
        }
    }
}