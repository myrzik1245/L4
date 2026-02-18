namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public interface INodeOptions<TState> where TState : class, IState
    {
        public INodeOptions<TState> AddTransition(Transition<TState> transition);
    }
}
