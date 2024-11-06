using Common.Infrastructure.Factories.Zenject;
using Common.Infrastructure.Services.AssetsManagement;
using Common.Infrastructure.Services.Coroutines;
using Common.Infrastructure.Services.InputServices;
using Common.Infrastructure.Services.SceneLoading;
using Common.Infrastructure.Services.StaticData;
using Common.Infrastructure.StateMachine;
using Common.Infrastructure.StateMachine.Factory;
using Common.Infrastructure.StateMachine.States;
using Common.Infrastructure.UI;
using NaughtyAttributes;
using UnityEngine;
using Zenject;

namespace Common.UnityLogic.MonoInstallers
{
    public sealed class ProjectContextInstaller : MonoInstaller
    {
        [SerializeField, Required] private CoroutineRunner _coroutineRunner;

        public override void InstallBindings()
        {
            BindGameStateMachine();
            BindServices();
            BindMonoServices();
            BindFactories();
        }
        
        private void BindMonoServices()
        {
            Container.Bind<ICoroutineRunner>().FromInstance(_coroutineRunner).AsSingle();
        }
        
        private void BindServices()
        {
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();
            Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
            Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
        }
        
        private void BindGameStateMachine()
        {
            Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
        
        private void BindFactories()
        {
            Container.Bind<IGameStatesFactory>().To<GameStatesFactory>().AsSingle();
            Container.Bind<IZenjectFactory>().To<ZenjectFactory>().AsSingle();
            Container.Bind<IScreenManager>().To<ScreenManager>().AsSingle();
        }
    }
}
