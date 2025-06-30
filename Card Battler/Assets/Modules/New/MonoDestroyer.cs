using UnityEngine;

namespace Modules.New
{
    public class MonoDestroyer : MonoBehaviour
    {
        public void Kill(GameObject go) => Destroy(go);
    }
}