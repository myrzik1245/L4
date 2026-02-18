using _Project.Code.Runtime.Utility.StateMachineCore.Node;
using Assets._Project.Code.Runtime.Utility.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public class StateMachine<TState> : State, IStateMachineOptions<TState>, IDisposable where TState : class, IState
    {
        private readonly List<StateNode<TState>> _states = new List<StateNode<TState>>();
        private StateNode<TState> _currentStateNode;

        protected TState CurrentState => _currentStateNode.State;

        public IStateMachineOptions<TState> AddState(TState state)
        {
            _states.Add(new StateNode<TState>(state));

            return this;
        }
        public IStateMachineOptions<TState> AddTransition(TState from, TState to, ICondition condition)
        {
            StateNode<TState> fromNode = _states.First(node => node.State == from);
            StateNode<TState> toNode = _states.First(node => node.State == to);

            fromNode.AddTransition(new Transition<TState>(condition, toNode));

            return this;
        }

        public void Update()
        {
            foreach (Transition<TState> transition in _currentStateNode.Transitions)
                if (transition.Condition.IsCompleate())
                    SwichState(transition.ToStateNode);
                    
        }

        public override void Enter()
        {
            base.Enter();

            SwichState(_states[0]);
        }

        public override void Exit()
        {
            base.Exit();

            _currentStateNode?.State.Exit();
        }

        public void Dispose()
        {
            foreach (StateNode<TState> stateNode in _states)
                if (stateNode.State is IDisposable disposable)
                    disposable.Dispose();

            _states.Clear();
        }

        private void SwichState(StateNode<TState> nextStateNode)
        {
            _currentStateNode?.State.Exit();
            _currentStateNode = nextStateNode;
            _currentStateNode.State.Enter();
        }
    }
}
