using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Utility.InputService;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Entities
{
    public class TeleportInputSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent<Vector3> _teleportRequest;
        private Transform _transform;
        private IInputService _inputService;
        private IPositionRandomizer _positionRandomizer;

        public TeleportInputSystem(IInputService inputService, IPositionRandomizer positionRandomizer)
        {
            _inputService = inputService;
            _positionRandomizer = positionRandomizer;
        }

        public void Initialize(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
            _transform = entity.Transform;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.TeleportButton.Down)
            {
                Vector3 teleportPosition = _positionRandomizer.GetPosition(_transform.position);
                _teleportRequest?.Invoke(teleportPosition);
            }
        }
    }
}
