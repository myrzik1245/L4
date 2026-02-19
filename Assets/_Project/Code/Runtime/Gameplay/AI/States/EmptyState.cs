using _Project.Code.Runtime.Utility.StateMachineCore;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.AI.States
{
    public class EmptyState : State, IUpdatableState
    {
        public void Update(float deltaTime)
        {
            Debug.Log("Я просто стою");
        }
    }
}
