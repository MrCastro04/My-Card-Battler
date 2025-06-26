using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Modules.Content.Card.Scripts;
using UnityEngine;
using UnityEngine.Splines;

namespace Modules.Content.Hand
{
    public class HandView : MonoBehaviour, IHand
    {
        [SerializeField] private SplineContainer _splineContainer;
        [SerializeField] private int _maxHandSize;

        public readonly List<CardView> CardsInHand = new();

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
                    .DOMove(splinePosition + transform.position + cardSpacing * i * Vector3.back, duration);

                CardsInHand[i].transform
                    .DORotate(Quaternion.identity.eulerAngles, duration);
            }

            yield return new WaitForSeconds(duration);
        }
    }
}