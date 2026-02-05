using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntitySystems
{
    public class RigidbodyMovementSystem : IEntitySystem, IInitializable, IUpdatable
    {
        private ReactiveVariable<Vector3> _direction;
        private ReactiveVariable<Vector3> _velocity;
        private ReactiveVariable<float> _speed;
        private Rigidbody _rigidbody;

        public void Initialize(Entity entity)
        {
            _direction = entity.GetComponent<MoveDirectionComponent>().Value;
            _velocity = entity.GetComponent<VelocityComponent>().Value;
            _speed = entity.GetComponent<MoveSpeedComponent>().Value;
            _rigidbody = entity.GetComponent<RigidbodyComponent>().Value;
        }

        public void Update(float deltaTime)
        {
            _velocity.Value = _direction.Value * (_speed.Value * deltaTime);
            _rigidbody.velocity = _velocity.Value;
        }
    }
}
