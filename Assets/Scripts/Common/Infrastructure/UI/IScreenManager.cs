namespace Common.Infrastructure.UI
{
    public interface IScreenManager
    {
        void ShowLoadingCurtain();
        void HideLoadingCurtain();
        void ShowWindow<TData>(TData data) where TData : IScreenArgs;
        void Hide<TData>(TData data) where TData : IScreenArgs;
    }
}