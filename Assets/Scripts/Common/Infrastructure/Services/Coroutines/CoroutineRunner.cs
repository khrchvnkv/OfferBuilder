using UnityEngine;

namespace Common.Infrastructure.Services.Coroutines
{
    public sealed class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public void StopCoroutineSafe(Coroutine coroutine)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
            }
        }
    }
}