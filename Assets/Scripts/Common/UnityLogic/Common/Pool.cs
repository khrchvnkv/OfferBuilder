using System.Collections.Generic;
using UnityEngine;

namespace Common.UnityLogic.Common
{
    public class Pool<T> where T : MonoBehaviour
    {
        private readonly T _prefab;
        private readonly Transform _container;
        private readonly Queue<T> _queue;
        
        public Pool(T prefab, Transform container)
        {
            _prefab = prefab;
            _container = container;
            _queue = new Queue<T>();
        }

        public T Rent()
        {
            if (!_queue.TryDequeue(out var instance))
            {
                instance = Instantiate();
            }

            instance.gameObject.SetActive(true);
            return instance;
        }

        public void Return(in T instance)
        {
            _queue.Enqueue(instance);
            instance.gameObject.SetActive(false);
        }

        private T Instantiate() => Object.Instantiate(_prefab, _container);
    }
}