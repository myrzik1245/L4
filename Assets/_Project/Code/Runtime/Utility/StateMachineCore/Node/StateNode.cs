using System.Collections.Generic;

namespace _Project.Code.Runtime.Utility.StateMachineCore.Node
{
    public class StateNode<TState> : INodeOptions<TState> where TState : class, IState
    {
        private readonly List<Transition<TState>> _transitions = new List<Transition<TState>>();

        public StateNode(TState state)
        {
            State = state;
        }

        public IReadOnlyCollection<Transition<TState>> Transitions => _transitions;
        public readonly TState State;

        public INodeOptions<TState> AddTransition(Transition<TState> transition)
        {
            _transitions.Add(transition);
            return this;
        }
    }
}
