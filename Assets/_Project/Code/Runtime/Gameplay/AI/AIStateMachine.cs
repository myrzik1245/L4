using _Project.Code.Runtime.Utility.StateMachineCore;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.AI
{
    public class AIStateMachine : StateMachine<IUpdatableState>, IUpdatableState
    {
        public void Update(float deltaTime)
        {
            Update();
            CurrentState?.Update(deltaTime);
        }
    }
}
