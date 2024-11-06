using Common.Infrastructure.UI;

namespace Common.UnityLogic.UI.OfferConstructor
{
    public class OfferConstructorScreen : ScreenBase<OfferConstructorScreen.Args>
    {
        private readonly OfferConstructorView _view;

        public class Args : IScreenArgs
        { }
        
        public OfferConstructorScreen(OfferConstructorView view)
        {
            _view = view;
        }

        protected override void PrepareForShowing()
        {
            base.PrepareForShowing();
            _view.Show();
        }

        protected override void PrepareForHiding()
        {
            base.PrepareForHiding();
            _view.Hide();
        }
    }
}