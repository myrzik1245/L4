using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems
{
    public class CharacterControllerMovementSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<Vector3> _velocity;
        private ReactiveVariable<float> _speed;
        private CharacterController _characterController;

        public void Initialize(Entity entity)
        {
            _direction = entity.GetComponent<MoveDirectionComponent>().Value;
            _velocity = entity.GetComponent<VelocityComponent>().Value;
            _speed = entity.GetComponent<MoveSpeedComponent>().Value;
            _characterController = entity.GetComponent<CharacterControllerComponent>().Value;
        }

        public void Update(float deltaTime)
        {
            _velocity.Value = _direction.Value * (_speed.Value * deltaTime);
            _characterController.Move(_velocity.Value);
        }
    }
}
