namespace Common.Infrastructure.StateMachine.Factory
{
    public interface IGameStatesFactory
    {
        TState GetState<TState>() where TState : IExitableState;
    }
}