using UnityEngine;

namespace Modules.Core.Utils.Mono_Destroyer
{
    public class MonoDestroyer : MonoBehaviour
    {
        public void Kill(GameObject go) => Destroy(go);
    }
}