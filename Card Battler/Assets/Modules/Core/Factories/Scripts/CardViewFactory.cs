using DG.Tweening;
using Modules.Content.Card.Scripts;
using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace Modules.Core.Factories.Scripts
{
    public class CardViewFactory : ICardViewFactory
    {
        private Object _cardViewPrefab = null;

        private readonly DiContainer _diContainer;

        public CardViewFactory(DiContainer diContainer)
        { 
            _diContainer = diContainer;
        }

        public void Load()
        {
            _cardViewPrefab = Resources.Load<CardView>(Constants.Constants.CARD_VIEW_PREFAB_PATH);
        }

        public CardView Create(CardModel cardModel, Vector3 position)
        {
            CardView newCardView = _diContainer
                .InstantiatePrefabForComponent<CardView>(_cardViewPrefab,position,quaternion.identity, null);
            
            newCardView.Setup(cardModel);
            
            newCardView.transform.localScale = Vector3.zero;

            newCardView.transform.DOScale(Vector3.one, 0.15f);

            return newCardView;
        }
    }
}