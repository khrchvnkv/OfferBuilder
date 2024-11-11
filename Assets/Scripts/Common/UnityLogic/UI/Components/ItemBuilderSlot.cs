using System;
using Common.StaticData;
using TMPro;
using UnityEngine;

namespace Common.UnityLogic.UI.Components
{
    public sealed class ItemBuilderSlot : MonoBehaviour
    {
        [SerializeField] private ItemSlot _slot;
        [SerializeField] private TMP_InputField _inputField;

        public ItemStaticData Item { get; private set; }

        public void Setup(in ItemStaticData item)
        {
            Item = item;
            _slot.SetData(item.Icon, item.LimitInSlot.ToString());
        }

        public bool HasCount(out int count)
        {
            count = 0;
            if (string.IsNullOrWhiteSpace(_inputField.text)) return false;

            if (Int32.TryParse(_inputField.text, out count) && count > 0)
            {
                return true;
            }

            return false;
        }
    }
}