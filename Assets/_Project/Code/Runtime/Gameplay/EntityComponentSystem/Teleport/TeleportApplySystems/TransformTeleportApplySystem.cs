using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using System;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportApplySystems
{
    public class TransformTeleportApplySystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private IDisposable _subscription;

        public void Initialize(Entity entity)
        {
            _subscription = entity.TeleportEvent.Subscribe(position => entity.Transform.position = position);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
