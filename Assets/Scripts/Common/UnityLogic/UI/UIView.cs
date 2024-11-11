using UnityEngine;
using Zenject;

namespace Common.UnityLogic.UI
{
    public class UIView : MonoBehaviour, IInitializable
    {
        public void Initialize() => OnInitialize();

        public void Show()
        {
            Subscribe();
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            Unsubscribe();
            gameObject.SetActive(false);
            Cleanup();
        }
        
        protected virtual void OnInitialize() { }
        protected virtual void Subscribe() { }
        protected virtual void Unsubscribe() { }
        protected virtual void Cleanup() { }
    }
}