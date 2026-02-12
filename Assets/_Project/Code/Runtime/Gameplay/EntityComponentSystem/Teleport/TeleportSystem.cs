using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportHandler;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Conditions;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using System;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport
{
    public class TeleportSystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private ReactiveEvent _request;
        private ReactiveEvent<Vector3> _teleportEvent;

        private ITeleportHandler _teleportHandler;
        private readonly IPositionRandomizer _positionRandomizer;
        private readonly ICondition _teleportCondition;

        private IDisposable _teleportRequestDisposable;

        public TeleportSystem(IPositionRandomizer positionRandomizer, ICondition teleportCondition)
        {
            _positionRandomizer = positionRandomizer;
            _teleportCondition = teleportCondition;
        }

        public void Initialize(Entity entity)
        {
            _request = entity.TeleportRequest;
            _teleportEvent = entity.TeleportEvent;

            if (entity.TryGetComponent(out RigidbodyComponent rigidbodyComponent))
                _teleportHandler = new RigidbodyTeleportHandler(rigidbodyComponent.Value);

            else if (entity.TryGetComponent(out TransformComponent transformComponent))
                _teleportHandler = new TransformTeleportHandler(transformComponent.Value);

            else
                throw new ArgumentException($"{nameof(entity)} don't has needed component");

            _teleportRequestDisposable = _request.Subscribe(OnTeleportRequest);
        }

        public void Dispose()
        {
            _teleportRequestDisposable?.Dispose();
        }

        private void OnTeleportRequest()
        {
            if (_teleportCondition.IsCompleate())
            {
                Vector3 postion = _positionRandomizer.GetPosition();
                _teleportHandler.Execute(postion);
                _teleportEvent.Invoke(postion);
            }
        }
    }
}
