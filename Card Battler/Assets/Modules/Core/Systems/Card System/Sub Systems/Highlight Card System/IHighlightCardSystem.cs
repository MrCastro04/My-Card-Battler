using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Core.Systems.Card_System.Sub_Systems.Highlight_Card_System
{
    public interface IHighlightCardSystem
    {
        void Show(CardModel cardModel, Vector3 position);
        void Hide();
    }
}