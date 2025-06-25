using Modules.Content.Card.Scripts;
using Modules.Core.Factories;
using UnityEngine;
using Zenject;

namespace Modules
{
    public class TestSystem : MonoBehaviour
    {
        [SerializeField] private CardData _cardData;
        
        private ICardViewFactory _cardViewFactory;
        
        [Inject]
        private void Construct(ICardViewFactory cardViewFactory)
        {
            _cardViewFactory = cardViewFactory;
            
            _cardViewFactory.Load();
            
            _cardViewFactory.Create(new(_cardData), Vector3.zero);
        }
    }
}