using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using Modules.Content.Hand.Scripts;
using UnityEngine;
using UnityEngine.Splines;
using Zenject;

namespace Modules.Core.Systems.Hand_System
{
    public class HandSystem : IHand
    {
        private readonly List<CardView> CardsInHand;
        private readonly SplineContainer _splineContainer;
        private readonly int _maxHandSize;

        public Vector3 HandPosition { get; private set; }
        

        [Inject] public HandSystem(int maxHandSize, SplineContainer splineContainer, Vector3 handPosition)
        {
            _splineContainer = splineContainer;

            _maxHandSize = maxHandSize;

            HandPosition = handPosition;

            CardsInHand = new();
        }

        public IEnumerator AddCard(CardView cardView)
        {
            CardsInHand.Add(cardView);

            yield return UpdateCardsPosition(0.15f);
        }

        public IEnumerator UpdateCardsPosition(float duration)
        {
            if (CardsInHand.Count == 0) yield break;

            float cardSpacing = 1f / _maxHandSize;

            float firstCardPosition = 0.5f - (CardsInHand.Count - 1) * cardSpacing / 2;

            Spline spline = _splineContainer.Spline;

            for (int i = 0; i < CardsInHand.Count; i++)
            {
                float position = firstCardPosition + i * cardSpacing;

                Vector3 splinePosition = spline.EvaluatePosition(position);

                CardsInHand[i].transform
                    .DOMove(splinePosition + HandPosition + cardSpacing * i * Vector3.back, duration);

                CardsInHand[i].transform
                    .DORotate(Quaternion.identity.eulerAngles, duration);
            }

            yield return new WaitForSeconds(duration);
        }
    }
}