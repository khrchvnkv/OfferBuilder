using Common.Infrastructure.Services.StaticData;
using Common.Infrastructure.UI;
using Common.UnityLogic.UI.OfferConstructor;

namespace Common.Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IScreenManager _screenManager;
        private readonly IStaticDataService _staticDataService;

        public GameLoopState(
            IScreenManager screenManager, 
            IStaticDataService staticDataService)
        {
            _screenManager = screenManager;
            _staticDataService = staticDataService;
        }

        public void Enter() => 
            _screenManager.ShowWindow(new OfferConstructorScreen.Args(_staticDataService.ItemsStaticData));

        public void Exit()
        { }
    }
}