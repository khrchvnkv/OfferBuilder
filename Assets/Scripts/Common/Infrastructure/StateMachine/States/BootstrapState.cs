using Common.Infrastructure.Services.StaticData;
using Common.Infrastructure.UI;

namespace Common.Infrastructure.StateMachine.States
{
    /// <summary>
    /// Data loading
    /// </summary>
    public class BootstrapState : IState
    {
        private readonly IStaticDataService _staticDataService;
        private readonly IScreenManager _screenManager;
        private readonly IGameStateMachine _gameStateMachine;

        public BootstrapState(
            IStaticDataService staticDataService, 
            IScreenManager screenManager, 
            IGameStateMachine gameStateMachine)
        {
            _staticDataService = staticDataService;
            _screenManager = screenManager;
            _gameStateMachine = gameStateMachine;
        }
        
        public void Enter()
        {
            ShowLoadingCurtain();
            LoadStaticData();
            
            _gameStateMachine.Enter<LoadLevelState>();
        }
        
        public void Exit()
        { }
        
        private void LoadStaticData() => _staticDataService.LoadData();
        
        private void ShowLoadingCurtain() => _screenManager.ShowLoadingCurtain();
    }
}