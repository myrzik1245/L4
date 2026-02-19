using _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Components;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Damage
{
    public class AttackOnTeleportSystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private ReactiveVariable<int> _damage;
        private ReactiveVariable<float> _radius;
        private Entity _selfEntity;

        private IDisposable _teleportEvent;

        public void Initialize(Entity entity)
        {
            _teleportEvent = entity.TeleportEvent.Subscribe(OnTeleport);
            _damage = entity.Damage;
            _radius = entity.AttackRadius;

            _selfEntity = entity;
        }

        public void Dispose()
        {
            _teleportEvent.Dispose();
        }

        private void OnTeleport(Vector3 position)
        {
            Collider[] colliders = Physics.OverlapSphere(position, _radius.Value);

            IEnumerable<Entity> entities = colliders
                .Select(colider => colider.GetComponent<MonoEntity>())
                .Where(monoEntity => monoEntity != null)
                .Select(monoEntity => monoEntity.OwnerEntity)
                .Where(entity => entity != _selfEntity);

            foreach (Entity entity in entities)
                if (entity.TryGetComponent(out DamageRequest damageRequest))
                    damageRequest.Value?.Invoke(_damage.Value);
        }
    }
}
