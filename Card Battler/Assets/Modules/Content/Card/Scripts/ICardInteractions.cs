using Modules.Core.Utils.Mouse_Util;

namespace Modules.Content.Card.Scripts
{
    public interface ICardInteractions
    {
        MouseUtil MouseUtil { get; }
        bool IsDragging { get; }
        void SetDragStatus(bool status);
        bool CanPlayCard(int manaAmount);
        bool CanHover();
        bool CanInteract();
    }
}