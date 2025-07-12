using UnityEngine;

namespace Modules.Core.Utils.Collider_Activator
{
    public class ColliderActivator
    {
        public void Actived(Collider collider) => collider.enabled = true;

        public void Disable(Collider collider) => collider.enabled = false;
    }
}