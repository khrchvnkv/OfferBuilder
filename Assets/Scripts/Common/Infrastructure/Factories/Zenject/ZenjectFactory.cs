using UnityEngine;
using Zenject;

namespace Common.Infrastructure.Factories.Zenject
{
    public class ZenjectFactory : IZenjectFactory
    {
        private readonly IInstantiator _instantiator;

        public ZenjectFactory(IInstantiator instantiator) => _instantiator = instantiator;

        public GameObject Instantiate(GameObject gameObject) =>
            _instantiator.InstantiatePrefab(gameObject);

        public GameObject Instantiate(GameObject gameObject, Transform parent) =>
            _instantiator.InstantiatePrefab(gameObject, parent);

        public T Instantiate<T>(T behaviour) where T : MonoBehaviour =>
            _instantiator.InstantiatePrefab(behaviour).GetComponent<T>();
        public T Instantiate<T>(T behaviour, Transform parent) where T : MonoBehaviour =>
            _instantiator.InstantiatePrefab(behaviour, parent).GetComponent<T>();

        public T Instantiate<T>(T behaviour, Vector3 position, Transform parent = null) where T : MonoBehaviour =>
            _instantiator.InstantiatePrefab(behaviour, position, Quaternion.identity, parent).GetComponent<T>();

        public T Instantiate<T>(T behaviour, Vector3 position, Quaternion quaternion, Transform parent = null)
            where T : MonoBehaviour =>
            _instantiator.InstantiatePrefab(behaviour, position, quaternion, parent).GetComponent<T>();
    }
}