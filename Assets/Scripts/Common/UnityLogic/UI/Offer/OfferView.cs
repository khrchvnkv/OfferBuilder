using System;
using System.Collections.Generic;
using Common.UnityLogic.Common;
using Common.UnityLogic.UI.Components;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Common.UnityLogic.UI.Offer
{
    public sealed class OfferView : UIView
    {
        [SerializeField] private Transform _itemsContainer;
        [SerializeField] private ItemSlot _itemSlotPrefab;
        [SerializeField] private Button _backButton;

        [Header("Content")] 
        [SerializeField] private TMP_Text _titleText;
        [SerializeField] private TMP_Text _descText;
        [SerializeField] private TMP_Text _discountPercentText;
        [SerializeField] private TMP_Text _discountPriceText;
        [SerializeField] private TMP_Text _totalPriceText;
        [SerializeField] private Image _offerImage;

        private readonly List<ItemSlot> _slots = new List<ItemSlot>();
        private Pool<ItemSlot> _pool;

        public event Action OnBackButtonClicked;

        public void SetTitle(in string titleText) => _titleText.text = titleText;
        
        public void SetDescription(in string description) => _descText.text = description;

        public void SetOfferIcon(in Sprite icon) => _offerImage.sprite = icon;

        public void ShowDiscountPercent(in string discountPercentText)
        {
            _discountPercentText.text = discountPercentText;
            _discountPercentText.gameObject.SetActive(true);
        }
        
        public void HideDiscountPercent()
        {
            _discountPercentText.text = string.Empty;
            _discountPercentText.gameObject.SetActive(false);
        }
        
        public void SetDiscountPrice(in string discountPrice) => _discountPriceText.text = discountPrice;

        public void ShowTotalPrice(in string totalPrice)
        {
            _totalPriceText.text = totalPrice;
            _totalPriceText.gameObject.SetActive(true);
        }
        
        public void HideTotalPrice()
        {
            _totalPriceText.text = string.Empty;
            _totalPriceText.gameObject.SetActive(false);
        }


        public void SetOfferItems(in List<OfferItem> offerItems)
        {
            foreach (var item in offerItems)
            {
                var count = item.Count;

                while (count > 0)
                {
                    var slotInstance = _pool.Rent();
                    _slots.Add(slotInstance);

                    var itemCount = Math.Min(item.Item.LimitInSlot, count);
                    slotInstance.SetData(item.Item.Icon, itemCount.ToString());
                    count -= item.Item.LimitInSlot;
                }
            }
        }

        protected override void OnInitialize()
        {
            base.OnInitialize();
            _pool = new Pool<ItemSlot>(_itemSlotPrefab, _itemsContainer);
        }

        protected override void Subscribe()
        {
            base.Subscribe();
            _backButton.onClick.AddListener(BackButtonClicked);
        }

        protected override void Unsubscribe()
        {
            base.Unsubscribe();
            _backButton.onClick.RemoveListener(BackButtonClicked);
        }

        protected override void Cleanup()
        {
            base.Cleanup();
            foreach (var slot in _slots)
            {
                _pool.Return(slot);
            }
            _slots.Clear();
        }

        private void BackButtonClicked() => OnBackButtonClicked?.Invoke();
    }
}