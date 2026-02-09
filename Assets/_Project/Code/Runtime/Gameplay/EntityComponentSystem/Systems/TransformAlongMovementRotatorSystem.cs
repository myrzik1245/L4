using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems
{
    public class TransformAlongMovementRotatorSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<float> _speed;
        private Transform _transform;

        public void Initialize(Entity entity)
        {
            _movementDirection = entity.GetComponent<MoveDirectionComponent>().Value;
            _speed = entity.GetComponent<RotationSpeedComponent>().Value;
            _transform = entity.GetComponent<TransformComponent>().Value;
        }

        public void Update(float deltaTime)
        {
            if (_movementDirection.Value == Vector3.zero)
                return;

            Quaternion lockRotation = Quaternion.LookRotation(_movementDirection.Value);
            _transform.rotation
                = Quaternion.RotateTowards(_transform.rotation, lockRotation, _speed.Value * deltaTime);
        }
    }
}
