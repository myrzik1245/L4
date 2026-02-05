using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems
{
    public class CharacterControllerAlongMovementRotatorSystem : IEntitySystem, IInitializable, IUpdatable
    {
        private ReactiveVariable<Vector3> _movementDirection;
        private ReactiveVariable<float> _speed;
        private CharacterController _characterController;

        public void Initialize(Entity entity)
        {
            _movementDirection = entity.GetComponent<MoveDirectionComponent>().Value;
            _speed = entity.GetComponent<RotationSpeedComponent>().Value;
            _characterController = entity.GetComponent<CharacterControllerComponent>().Value;
        }

        public void Update(float deltaTime)
        {
            if (_movementDirection.Value == Vector3.zero)
                return;

            Quaternion lockRotation = Quaternion.LookRotation(_movementDirection.Value);
            _characterController.transform.rotation
                = Quaternion.RotateTowards(_characterController.transform.rotation, lockRotation, _speed.Value * deltaTime);
        }
    }
}
