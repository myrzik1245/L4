using _Project.Code.Runtime.Utility.StateMachineCore;

namespace _Project.Code.Runtime.Gameplay.AI
{
    public class AIStateMachine : StateMachine<IUpdatableState>, IUpdatableState
    {
        public void Update(float deltaTime)
        {
            CurrentState?.Update(deltaTime);
        }
    }
}
