using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using Modules.Core.Game_Actions;
using Modules.Core.Systems.Action_System.Scripts;
using Modules.Core.Utils.Coroutine_Runner;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Core.Systems.Hand_System
{
    public sealed class HandSystem : IHand, IInitializable,IDisposable
    {
        private readonly CoroutineRunner _coroutineRunner;
        private readonly ActionSystem _actionSystem;
        private readonly List<CardModel> _cardModelsInHand;
        private readonly List<CardView> _cardsViewInHand;
        private readonly SplineContainer _splineContainer;
        private readonly float _updateCardsInHandDuration;
        private readonly int _maxHandSize;

        public List<CardView> CardsViewInHand => _cardsViewInHand;
        public Vector3 Position { get; }
        
        [Inject]
        public HandSystem(
            CoroutineRunner coroutineRunner,
            ActionSystem actionSystem,
            float updateCardsInHandDuration,
            int maxHandSize,
            SplineContainer splineContainer,
            Vector3 position)
        {
            _cardModelsInHand = new();

            _cardsViewInHand = new();

            _coroutineRunner = coroutineRunner;
            
            _actionSystem = actionSystem;
            
            _updateCardsInHandDuration = updateCardsInHandDuration;

            _maxHandSize = maxHandSize;

            _splineContainer = splineContainer;

            Position = position;
        }

        public void Initialize()
        {
         _actionSystem.SubscribeReaction<PlayCardGA>(POSTPlayCardReaction,ReactionTiming.POST);    
        }

        public void Dispose()
        {
            _actionSystem.UnsubscribeReaction<PlayCardGA>(POSTPlayCardReaction,ReactionTiming.POST);
        }

        public IEnumerator AddCard(CardView newCardView)
        {
            CardModel newCardModel = newCardView.CardModel;

            CardsViewInHand.Add(newCardView);

            _cardModelsInHand.Add(newCardModel);

            yield return UpdateCardsPosition(_updateCardsInHandDuration);
        }

        public IEnumerator RemoveCard(CardView discardedCardView)
        {
            CardModel discardedModel = discardedCardView.CardModel;

            _cardsViewInHand.Remove(discardedCardView);

            _cardModelsInHand.Remove(discardedModel);

            yield return UpdateCardsPosition(_updateCardsInHandDuration);
        }

        private IEnumerator UpdateCardsPosition(float duration)
        {
            if (CardsViewInHand.Count == 0) yield break;

            float cardSpacing = 1f / _maxHandSize;

            float firstCardPosition = 0.5f - (CardsViewInHand.Count - 1) * cardSpacing / 2;

            Spline spline = _splineContainer.Spline;

            for (int i = 0; i < CardsViewInHand.Count; i++)
            {
                float position = firstCardPosition + i * cardSpacing;

                Vector3 splinePosition = spline.EvaluatePosition(position);

                CardsViewInHand[i].transform
                    .DOMove(splinePosition + Position + cardSpacing * i * Vector3.back, duration);

                CardsViewInHand[i].transform
                    .DORotate(Quaternion.identity.eulerAngles, duration);
            }

            yield return new WaitForSeconds(duration);
        }

        private void POSTPlayCardReaction(PlayCardGA playCardGa)
        { 
            _coroutineRunner.Run(RemoveCard(playCardGa.PlayedCardView)); 
        }
    }
}