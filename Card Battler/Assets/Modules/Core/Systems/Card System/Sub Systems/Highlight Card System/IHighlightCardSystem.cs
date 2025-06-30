using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.New
{
    public interface IHighlightCardSystem
    {
        void Show(CardModel cardModel, Vector3 position);
        void Hide();
    }
}