using _Project.Code.Runtime.Utility.StateMachineCore.Node;
using Assets._Project.Code.Runtime.Utility.Conditions;

namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public class Transition<TState> where TState : class, IState
    {
        public Transition(ICondition condition, StateNode<TState> toStateNode)
        {
            Condition = condition;
            ToStateNode = toStateNode;
        }

        public readonly StateNode<TState> ToStateNode;
        public readonly ICondition Condition;
    }
}
