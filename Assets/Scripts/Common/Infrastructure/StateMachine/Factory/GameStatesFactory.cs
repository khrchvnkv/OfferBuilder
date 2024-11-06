using System;
using System.Collections.Generic;
using Zenject;

namespace Common.Infrastructure.StateMachine.Factory
{
    public class GameStatesFactory : IGameStatesFactory
    {
        private readonly IInstantiator _instantiator;
        private readonly Dictionary<Type, IExitableState> _statesMap;

        public GameStatesFactory(
            IInstantiator instantiator)
        {
            _instantiator = instantiator;
            _statesMap = new Dictionary<Type, IExitableState>();
        }

        public TState GetState<TState>() where TState : IExitableState
        {
            var stateType = typeof(TState);
            if (!_statesMap.TryGetValue(stateType, out var state))
            {
                state = _instantiator.Instantiate<TState>();
                _statesMap.Add(stateType, state);
            }

            return (TState)state;
        }
    }
}