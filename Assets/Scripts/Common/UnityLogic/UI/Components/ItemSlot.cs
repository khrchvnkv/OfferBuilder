using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UnityLogic.UI.Components
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private TMP_Text _countText;

        public void SetData(in Sprite icon, in string countText)
        {
            _icon.sprite = icon;
            _countText.text = countText;
        }
    }
}