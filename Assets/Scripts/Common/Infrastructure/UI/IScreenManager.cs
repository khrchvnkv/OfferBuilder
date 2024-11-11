using Zenject;

namespace Common.Infrastructure.UI
{
    public interface IScreenManager
    {
        void Resolve(in DiContainer container);
        void ShowLoadingCurtain();
        void HideLoadingCurtain();
        void ShowWindow<TScreenArgs>(TScreenArgs data) where TScreenArgs : IScreenArgs;
        void Hide<TScreenArgs>() where TScreenArgs : IScreenArgs;
    }
}