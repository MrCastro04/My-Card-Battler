namespace Modules.@new
{
    public interface ICardInteractions
    {
        MouseUtil MouseUtil { get; }
        bool IsDragging { get; }
        void SetDragStatus(bool status);
        bool CanHover();
        bool CanInteract();
    }
}