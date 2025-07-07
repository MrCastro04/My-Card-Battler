using System.Collections;
using UnityEngine;

namespace Modules.Core.Utils.Coroutine_Runner
{
    public class CoroutineRunner : MonoBehaviour
    {
        public void Run(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}