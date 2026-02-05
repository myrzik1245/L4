using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Code.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems
{
    public class InputSystem : IEntitySystem, IInitializable, IUpdatable
    {
        private IInputService _inputService;
        private ReactiveVariable<Vector3> _direction;

        public void Initialize(Entity entity)
        {
            _inputService = entity.GetComponent<InputComponent>().Value;
            _direction = entity.GetComponent<MoveDirectionComponent>().Value;
        }

        public void Update(float deltaTime)
        {
            Vector2 movement = _inputService.Movement;
            _direction.Value = new Vector3(movement.x, 0, movement.y);
        }
    }
}
