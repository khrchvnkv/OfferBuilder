using System;
using System.Collections.Generic;
using Common.UnityLogic.UI.LoadingScreen;
using Zenject;

namespace Common.Infrastructure.UI
{
    public sealed class ScreenManager : IScreenManager
    {
        private readonly LoadingCurtain _loadingCurtain;
        private readonly Dictionary<Type, IScreen> _screensMap;

        public ScreenManager(
            LoadingCurtain loadingCurtain)
        {
            _loadingCurtain = loadingCurtain;
            _screensMap = new Dictionary<Type, IScreen>();
        }
        
        public void Resolve(in DiContainer container)
        {
            var screens = container.ResolveAll<IScreen>();
            foreach (var screen in screens)
            {
                Register(screen);
            }
        }

        public void ShowLoadingCurtain() => _loadingCurtain.Show();

        public void HideLoadingCurtain() => _loadingCurtain.Hide();

        public void ShowWindow<TScreenArgs>(TScreenArgs data) where TScreenArgs : IScreenArgs
        {
            var argsType = typeof(TScreenArgs);
            if (_screensMap.TryGetValue(argsType, out var screen))
            {
                screen.Show(data);
                return;
            }
            
            ThrowNullScreenException(argsType);
        }

        public void Hide<TScreenArgs>() where TScreenArgs : IScreenArgs
        {
            var argsType = typeof(TScreenArgs);
            if (_screensMap.TryGetValue(argsType, out var screen))
            {
                screen.Hide();
                return;
            }
            
            ThrowNullScreenException(argsType);
        }

        private void Register(in IScreen screen)
        {
            _screensMap.Add(screen.ArgsType, screen);
            screen.Hide();
        }

        private void ThrowNullScreenException(in Type screenType) => 
            throw new NullReferenceException($"No window registered for data type {screenType}");
    }
}