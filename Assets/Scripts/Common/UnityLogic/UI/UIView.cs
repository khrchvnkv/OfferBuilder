using UnityEngine;

namespace Common.UnityLogic.UI
{
    public class UIView : MonoBehaviour
    {
        public void Show()
        {
            PrepareForShowing();
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            PrepareForHiding();
            gameObject.SetActive(false);
        }

        protected virtual void PrepareForShowing() { }
        
        protected virtual void PrepareForHiding() { }
    }
}