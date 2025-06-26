using DG.Tweening;
using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Core.Factories
{
    public class CardViewFactory : MonoBehaviour,ICardViewFactory
    {
        private const string PATH = "Card View";
        private CardView _cardViewPrefab = null;
        
        public void Load()
        {
            _cardViewPrefab = Resources.Load<CardView>(PATH);
        }

        public CardView Create(CardModel cardModel, Vector3 position)
        {
            CardView newCardView = Instantiate(_cardViewPrefab, position, Quaternion.identity, null);
            
            newCardView.Setup(cardModel);
            
            newCardView.transform.localScale = Vector3.zero;

            newCardView.transform.DOScale(Vector3.one, 0.15f);

            return newCardView;
        }
    }
}