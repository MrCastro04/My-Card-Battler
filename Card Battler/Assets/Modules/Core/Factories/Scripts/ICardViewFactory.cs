using Modules.Content.Card.Scripts;
using UnityEngine;

namespace Modules.Core.Factories.Scripts
{
    public interface ICardViewFactory
    {
        void Load();
        CardView Create(CardModel cardModel, Vector3 position);
    }
}