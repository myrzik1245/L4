using Assets._Project.Code.Runtime.Gameplay.Components;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Conditions;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using System;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport
{
    public class TeleportSystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private ReactiveEvent<Vector3> _request;
        private ReactiveEvent<Vector3> _teleportEvent;

        private readonly ICondition _teleportCondition;

        private IDisposable _teleportRequestDisposable;

        public TeleportSystem(ICondition teleportCondition)
        {
            _teleportCondition = teleportCondition;
        }

        public void Initialize(Entity entity)
        {
            _request = entity.TeleportRequest;
            _teleportEvent = entity.TeleportEvent;

            _teleportRequestDisposable = _request.Subscribe(OnTeleportRequest);
        }

        public void Dispose()
        {
            _teleportRequestDisposable?.Dispose();
        }

        private void OnTeleportRequest(Vector3 position)
        {
            if (_teleportCondition.IsCompleate())
                _teleportEvent.Invoke(position);
        }
    }
}
