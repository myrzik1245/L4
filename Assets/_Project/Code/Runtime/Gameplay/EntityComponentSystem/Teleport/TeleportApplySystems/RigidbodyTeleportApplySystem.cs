using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using System;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportApplySystems
{
    public class RigidbodyTeleportApplySystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private IDisposable _subscription;

        public void Initialize(Entity entity)
        {
            _subscription = entity.TeleportEvent.Subscribe((Vector3 position) => entity.Rigidbody.position = position);
        }

        public void Dispose()
        {
            _subscription.Dispose();
        }
    }
}
