using _Project.Code.Runtime.Utility.StateMachineCore;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.AI.States
{
    public class AIRandomTeleportationState : State, IUpdatableState
    {
        private readonly ReactiveEvent<Vector3> _teleportRequest;
        private readonly Transform _transform;
        private readonly IPositionRandomizer _positionRandomizer;
        private readonly float _cooldown;

        private float _time;

        public AIRandomTeleportationState(Entity entity, IPositionRandomizer positionRandomizer, float cooldown)
        {
            _teleportRequest = entity.TeleportRequest;
            _transform = entity.Transform;
            _cooldown = cooldown;
            _positionRandomizer = positionRandomizer;
        }

        public override void Enter()
        {
            _time = 0;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _cooldown)
            {
                _time = 0;
                _teleportRequest.Invoke(_positionRandomizer.GetPosition(_transform.position));
            }
        }
    }
}
