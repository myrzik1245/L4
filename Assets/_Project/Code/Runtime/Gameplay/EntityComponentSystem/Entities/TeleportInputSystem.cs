using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Utility.InputService;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Entities
{
    public class TeleportInputSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveEvent _teleportRequest;
        private IInputService _inputService;

        public TeleportInputSystem(IInputService inputService)
        {
            _inputService = inputService;
        }

        public void Initialize(Entity entity)
        {
            _teleportRequest = entity.TeleportRequest;
        }

        public void Update(float deltaTime)
        {
            if (_inputService.TeleportButton.Down)
                _teleportRequest?.Invoke();
        }
    }
}
