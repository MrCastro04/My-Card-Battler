using Modules.Content.Card.Scripts;
using Modules.New;
using UnityEngine;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Highlight_Card_System
{
    public sealed class HighlightCardSystem : IHighlightCardSystem
    {
        private readonly CardView _highlightCardViewPrefab;

        public HighlightCardSystem(CardView highlightCardViewPrefab)
        {
            _highlightCardViewPrefab = highlightCardViewPrefab;

            Setup();
        }

        public void Show(CardModel cardModel, Vector3 position)
        {
            _highlightCardViewPrefab.gameObject.transform.position = position;
            
            _highlightCardViewPrefab.Setup(cardModel);
            
            _highlightCardViewPrefab.gameObject.SetActive(true);
        }

        public void Hide()
        {
            _highlightCardViewPrefab.gameObject.SetActive(false);
        }

        private void Setup()
        {
            if (_highlightCardViewPrefab.gameObject.activeSelf)
            {
                _highlightCardViewPrefab.gameObject.SetActive(false);
            }
        }
    }
}