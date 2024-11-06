using Common.Infrastructure.Services.InputServices;

namespace Common.Infrastructure.StateMachine.States
{
    public class GameLoopState : IState
    {
        private readonly IInputService _inputService;

        public GameLoopState(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Enter()
        {
            _inputService.EnableInput();
        }

        public void Exit()
        {
            _inputService.DisableInput();
        }
    }
}