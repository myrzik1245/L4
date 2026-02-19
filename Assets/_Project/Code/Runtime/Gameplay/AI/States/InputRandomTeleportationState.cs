using _Project.Code.Runtime.Utility.StateMachineCore;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Utility.InputService;
using UnityEngine;

namespace _Project.Code.Runtime.Gameplay.AI.States
{
    public class InputRandomTeleportationState : State, IUpdatableState
    {
        private readonly ReactiveEvent<Vector3> _teleportEvent;
        private readonly Transform _transform;
        private readonly IPositionRandomizer _positionRandomizer;
        private readonly IInputService _inputService;

        public InputRandomTeleportationState(Entity entity, IInputService inputService, IPositionRandomizer positionRandomizer)
        {
            _teleportEvent = entity.TeleportEvent;
            _transform = entity.Transform;

            _inputService = inputService;
            _positionRandomizer = positionRandomizer;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.TeleportButton.Down)
                _teleportEvent?.Invoke(_positionRandomizer.GetPosition(_transform.position));
        }
    }
}
