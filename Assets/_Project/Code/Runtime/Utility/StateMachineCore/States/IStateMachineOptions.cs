using Assets._Project.Code.Runtime.Utility.Conditions;

namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public interface IStateMachineOptions<TState> where TState : class, IState
    {
        IStateMachineOptions<TState> AddState(TState state);
        IStateMachineOptions<TState> AddTransition(TState from, TState to, ICondition condition);
    }
}
