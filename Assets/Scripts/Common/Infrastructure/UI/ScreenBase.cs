using System;

namespace Common.Infrastructure.UI
{
    public abstract class ScreenBase<TScreenArgs> : IScreen where TScreenArgs : IScreenArgs
    {
        protected TScreenArgs Data;

        public Type ArgsType => typeof(TScreenArgs);

        public void Show(IScreenArgs windowData)
        {
            Data = (TScreenArgs)windowData;
            PrepareForShowing();
        }

        public void Hide()
        {
            PrepareForHiding();
            Data = default;
        }
        protected virtual void PrepareForShowing() { }
        protected virtual void PrepareForHiding() { }
    }
}