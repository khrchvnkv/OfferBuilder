using Common.Infrastructure.UI;
using Common.UnityLogic.UI.OfferConstructor;

namespace Common.Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IScreenManager _screenManager;

        public GameLoopState(
            IScreenManager screenManager)
        {
            _screenManager = screenManager;
        }

        public void Enter()
        {
            _screenManager.ShowWindow(new OfferConstructorScreen.Args());
        }

        public void Exit()
        { }
    }
}