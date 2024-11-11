using Common.Infrastructure.UI;
using Common.StaticData;

namespace Common.UnityLogic.UI.OfferConstructor
{
    public sealed class OfferConstructorScreen : ScreenBase<OfferConstructorScreen.Args>
    {
        public class Args : IScreenArgs
        {
            public readonly ItemStaticData[] Items;

            public  Args(ItemStaticData[] items)
            {
                Items = items;
            }
        }
        
        private readonly OfferConstructorView _view;
        private readonly IScreenManager _screenManager;
        
        public OfferConstructorScreen(
            OfferConstructorView view, 
            IScreenManager screenManager)
        {
            _view = view;
            _screenManager = screenManager;
        }

        protected override void PrepareForShowing()
        {
            base.PrepareForShowing();
            _view.ResetData();
            _view.SetupData(Data.Items);
            _view.OnBuildButtonClicked += Build;
            
            _view.Show();
        }

        protected override void PrepareForHiding()
        {
            base.PrepareForHiding();
            _view.OnBuildButtonClicked -= Build;
            
            _view.Hide();
        }

        private void Build()
        {
            var offerScreenArgs = _view.GetOfferScreenArgs();
            
            Hide();
            _screenManager.ShowWindow(offerScreenArgs);
        }
    }
}