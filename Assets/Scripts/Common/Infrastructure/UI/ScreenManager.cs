using System;
using System.Collections.Generic;
using System.Linq;
using Common.UnityLogic.UI.LoadingScreen;
using Zenject;

namespace Common.Infrastructure.UI
{
    public sealed class ScreenManager : IScreenManager, IInitializable
    {
        private readonly LoadingCurtain _loadingCurtain;
        private readonly Dictionary<Type, IScreen> _screensMap;

        public ScreenManager(
            LoadingCurtain loadingCurtain,
            IScreen[] screens)
        {
            _loadingCurtain = loadingCurtain;
            _screensMap = screens.ToDictionary(key => key.ArgsType, value => value);
        }
        
        public void Initialize()
        {
            foreach (var screenKeyValuePair in _screensMap)
            {
                screenKeyValuePair.Value.Hide();
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
        
        public void Hide<TScreenArgs>(TScreenArgs data) where TScreenArgs : IScreenArgs
        {
            var argsType = typeof(TScreenArgs);
            if (_screensMap.TryGetValue(argsType, out var screen))
            {
                screen.Hide();
                return;
            }
            
            ThrowNullScreenException(argsType);
        }

        private void ThrowNullScreenException(in Type screenType) => 
            throw new NullReferenceException($"No window registered for data type {screenType}");
    }
}