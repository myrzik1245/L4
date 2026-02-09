using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Code.Utility.Reactive.Variable;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.Factories
{
    public class EntitiesFactory
    {
        private readonly IInputService _inputService;

        public EntitiesFactory(IInputService inputService)
        {
            _inputService = inputService;
        }

        public Entity CreateCharacterControllerEntity()
        {
            Entity entity = CreateEmtyEntity();

            AddMovableComponents(entity, 1);
            AddRotatableComponents(entity, 500);

            entity
                .AddSystem(new CharacterControllerMovementSystem())
                .AddSystem(new TransformAlongMovementRotatorSystem())
                .AddSystem(new InputSystem(_inputService));

            return entity;
        }

        public Entity CreateRigidbodyPlayerEntity()
        {
            Entity entity = CreateEmtyEntity();

            AddMovableComponents(entity, 500);
            AddRotatableComponents(entity, 500);

            entity
                .AddSystem(new RigidbodyMovementSystem())
                .AddSystem(new RigidbodyAlongMovementRotatorSystem())
                .AddSystem(new InputSystem(_inputService));

            return entity;
        }

        public Entity CreateEmtyEntity()
        {
            return new Entity();
        }

        private void AddMovableComponents(Entity entity, float speed)
        {
            entity
                .AddComponent(new VelocityComponent() { Value = new ReactiveVariable<Vector3>(Vector3.zero) })
                .AddComponent(new MoveDirectionComponent() { Value = new ReactiveVariable<Vector3>(Vector3.zero) })
                .AddComponent(new MoveSpeedComponent() { Value = new ReactiveVariable<float>(speed) });
        }
        
        private void AddRotatableComponents(Entity entity, float rotationSpeed)
        {
            entity
                .AddComponent(new RotationSpeedComponent() { Value = new ReactiveVariable<float>(rotationSpeed) });
        }
    }
}
