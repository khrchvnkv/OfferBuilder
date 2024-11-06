using Common.Infrastructure.StateMachine.Factory;

namespace Common.Infrastructure.StateMachine
{
    public sealed class GameStateMachine : IGameStateMachine
    {
        private readonly IGameStatesFactory _gameStatesFactory;
        private IExitableState _activeState;

        public GameStateMachine(IGameStatesFactory gameStatesFactory)
        {
            _gameStatesFactory = gameStatesFactory;
        }
        
        public void Enter<TState>() where TState : class, IState
        {
            var state = ChangeState<TState>();
            state.Enter();
        }
        
        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            var state = ChangeState<TState>();
            state.Enter(payload);
        }
        
        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            var state = _gameStatesFactory.GetState<TState>();
            _activeState = state;
            return state;
        }
    }
}