using System;

namespace Common.Infrastructure.UI
{
    public abstract class ScreenBase<TScreenArgs> : IScreen where TScreenArgs : IScreenArgs
    {
        protected TScreenArgs WindowData;

        public Type ArgsType => typeof(TScreenArgs);

        public void Show(IScreenArgs windowData)
        {
            WindowData = (TScreenArgs)windowData;
            PrepareForShowing();
        }

        public void Hide()
        {
            PrepareForHiding();
            WindowData = default;
        }
        protected virtual void PrepareForShowing() { }
        protected virtual void PrepareForHiding() { }
    }
}