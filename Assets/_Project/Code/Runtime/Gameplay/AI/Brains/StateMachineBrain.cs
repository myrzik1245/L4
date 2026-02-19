namespace _Project.Code.Runtime.Gameplay.AI.Brains
{
    public class StateMachineBrain : Brain
    {
        private readonly AIStateMachine _aiStateMachine;

        public StateMachineBrain(AIStateMachine aiStateMachine)
        {
            _aiStateMachine = aiStateMachine;
        }

        public override void Enable()
        {
            base.Enable();
            _aiStateMachine.Enter();
        }

        public override void Disable()
        {
            base.Disable();
            _aiStateMachine.Exit();
        }

        public override void Dispose()
        {
            base.Dispose();
            _aiStateMachine.Dispose();
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _aiStateMachine.Update(deltaTime);
        }
    }
}
