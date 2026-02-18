using Assets._Project.Code.Runtime.Utility.Reactive.Event;

namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public interface IState
    {
        IReadOnlyEvent Entered { get; }
        IReadOnlyEvent Exited { get; }

        void Enter();
        void Exit();
    }
}
