using Common.Infrastructure.Services.SceneLoading;
using Common.Infrastructure.UI;
using Cysharp.Threading.Tasks;

namespace Common.Infrastructure.StateMachine.States
{
    public class LoadLevelState : IState
    {
        private readonly ISceneLoader _sceneLoader;
        private readonly IScreenManager _screenManager;
        private readonly IGameStateMachine _gameStateMachine;

        public LoadLevelState(
            ISceneLoader sceneLoader, 
            IScreenManager screenManager, 
            IGameStateMachine gameStateMachine)
        {
            _sceneLoader = sceneLoader;
            _screenManager = screenManager;
            _gameStateMachine = gameStateMachine;
        }

        public void Enter() => 
            _sceneLoader.LoadSceneAsync(Constants.Scenes.GameScene, OnGameSceneLoaded).Forget();
        
        public void Exit() => _screenManager.HideLoadingCurtain();
        
        private void OnGameSceneLoaded() => _gameStateMachine.Enter<GameLoopState>();
    }
}