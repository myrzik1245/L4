using Assets._Project.Code.Runtime.Utility.Reactive.Event;

namespace _Project.Code.Runtime.Utility.StateMachineCore
{
    public abstract class State :  IState
    {
        private readonly ReactiveEvent _entered = new ReactiveEvent();
        private readonly ReactiveEvent _exited = new ReactiveEvent();

        public IReadOnlyEvent Entered =>  _entered;  
        public IReadOnlyEvent Exited => _exited;

        public virtual void Enter()
        {
            _entered?.Invoke();
        }

        public virtual void Exit()
        {
            _exited?.Invoke();
        }
    }
}
