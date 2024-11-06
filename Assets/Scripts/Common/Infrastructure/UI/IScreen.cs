using System;

namespace Common.Infrastructure.UI
{
    public interface IScreen
    {
        Type ArgsType { get; }
        void Show(IScreenArgs windowData);
        void Hide();
    }
}