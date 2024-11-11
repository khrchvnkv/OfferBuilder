using System.Collections.Generic;
using Common.Infrastructure.Services.AssetsManagement;
using Common.Infrastructure.Services.StaticData;
using Common.Infrastructure.UI;
using Common.UnityLogic.UI.Components;
using Common.UnityLogic.UI.OfferConstructor;
using UnityEngine;

namespace Common.UnityLogic.UI.Offer
{
    public sealed class OfferScreen : ScreenBase<OfferScreen.Args>
    {
        public class Args : IScreenArgs
        {
            public readonly string Title;
            public readonly string Description;
            public readonly float Price;
            public readonly int Discount;
            public readonly string IconName;
            public readonly List<OfferItem> OfferItems;

            public bool HasDiscount => Discount > 0;

            public Args(
                string title, 
                string description, 
                float price, 
                int discount, 
                string iconName, 
                List<OfferItem> offerItems)
            {
                Title = title;
                Description = description;
                Price = price;
                Discount = discount;
                IconName = iconName;
                OfferItems = offerItems;
            }
        }

        private const string DiscountPercentFormat = "-{0}%";
        private const string IconLocationFormat = "UI/{0}";
        
        private readonly OfferView _view;
        private readonly IScreenManager _screenManager;
        private readonly IStaticDataService _staticDataService;
        private readonly IAssetProvider _assetProvider;

        public OfferScreen(
            OfferView view, 
            IScreenManager screenManager, 
            IStaticDataService staticDataService, 
            IAssetProvider assetProvider)
        {
            _view = view;
            _screenManager = screenManager;
            _staticDataService = staticDataService;
            _assetProvider = assetProvider;
        }

        protected override void PrepareForShowing()
        {
            base.PrepareForShowing();
            
            _view.SetTitle(Data.Title);
            _view.SetDescription(Data.Description);

            var iconName = string.Format(IconLocationFormat, Data.IconName);
            var icon = _assetProvider.Load<Sprite>(iconName);
            _view.SetOfferIcon(icon);
            var priceText = $"{Data.Price:0.00}";
            
            if (Data.HasDiscount)
            {
                _view.ShowDiscountPercent(string.Format(DiscountPercentFormat, Data.Discount));
                var discountPrice = Data.Price * (100 - Data.Discount) / 100;
                _view.SetDiscountPrice($"{discountPrice:0.00}");
                _view.ShowTotalPrice(priceText);
            }
            else
            {
                _view.HideDiscountPercent();
                _view.SetDiscountPrice(priceText);
                _view.HideTotalPrice();
                
            }
            _view.SetOfferItems(Data.OfferItems);
            
            _view.OnBackButtonClicked += BackButtonClicked;
            
            _view.Show();
        }

        protected override void PrepareForHiding()
        {
            base.PrepareForHiding();
            _view.OnBackButtonClicked -= BackButtonClicked;
            
            _view.Hide();
        }

        private void BackButtonClicked()
        {
            Hide();
            _screenManager.ShowWindow(new OfferConstructorScreen.Args(_staticDataService.ItemsStaticData));
        }
    }
}