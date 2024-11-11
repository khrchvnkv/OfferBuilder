using System;
using System.Collections.Generic;
using Common.StaticData;
using Common.UnityLogic.Common;
using Common.UnityLogic.UI.Components;
using Common.UnityLogic.UI.Components.InputField;
using Common.UnityLogic.UI.Offer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UnityLogic.UI.OfferConstructor
{
    public sealed class OfferConstructorView : UIView
    {
        private const string DiscountTextFormat = "Discount: {0}%";
        
        [SerializeField] private Transform _slotsContainer;
        [SerializeField] private ItemBuilderSlot _slotPrefab;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private TMP_InputField _titleInputField;
        [SerializeField] private TMP_InputField _descInputField;
        [SerializeField] private PositiveFloatInputField _priceInputField;
        [SerializeField] private TMP_Text _discountText;
        [SerializeField] private Slider _discountSlider;
        [SerializeField] private TMP_InputField _iconNameInputField;

        private readonly List<ItemBuilderSlot> _slots = new List<ItemBuilderSlot>();

        private Pool<ItemBuilderSlot> _pool;

        public event Action OnBuildButtonClicked;

        public void ResetData()
        {
            _titleInputField.text = string.Empty;
            _descInputField.text = string.Empty;
            _priceInputField.ResetInputValue();
            _iconNameInputField.text = string.Empty;
        }
        
        public void SetupData(in ItemStaticData[] items)
        {
            for (int i = 0; i < items.Length; i++)
            {
                var slotInstance = _pool.Rent();
                _slots.Add(slotInstance);
                _slots[i].Setup(items[i]);
            }
        }

        public OfferScreen.Args GetOfferScreenArgs()
        {
            var result = new List<OfferItem>();
            foreach (var slot in _slots)
            {
                if (slot.HasCount(out var count))
                {
                    result.Add(new OfferItem(slot.Item, count));
                }
            }
            
            return new OfferScreen.Args(
                _titleInputField.text,
                _descInputField.text,
                _priceInputField.GetValue(),
                (int)_discountSlider.value,
                _iconNameInputField.text,
                result);
        }
        
        protected override void OnInitialize()
        {
            base.OnInitialize();
            _pool = new Pool<ItemBuilderSlot>(_slotPrefab, _slotsContainer);
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            _confirmButton.onClick.AddListener(ClickConfirmButton);
            _discountSlider.onValueChanged.AddListener(SliderValueChanged);
            SliderValueChanged(_discountSlider.value);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            _confirmButton.onClick.RemoveListener(ClickConfirmButton);
            _discountSlider.onValueChanged.RemoveListener(SliderValueChanged);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            foreach (var slot in _slots)
            {
                _pool.Return(slot);
            }
            _slots.Clear();

            _discountSlider.value = _discountSlider.minValue;
        }

        private void ClickConfirmButton() => OnBuildButtonClicked?.Invoke();
        
        private void SliderValueChanged(float newValue) => _discountText.text = string.Format(DiscountTextFormat, (int)newValue);
    }
}