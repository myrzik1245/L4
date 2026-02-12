using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using System;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Health
{
    public class TakeDamageSystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private ReactiveVariable<int> _health;

        private IDisposable _takeDamageRequest;

        public void Initialize(Entity entity)
        {
            _health = entity.Health;
            _takeDamageRequest = entity.DamageRequest.Subscribe(OnTakeDamage);
        }

        public void Dispose()
        {
            _takeDamageRequest.Dispose();
        }

        private void OnTakeDamage(int damage)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException();

            _health.Value = Mathf.Max(0, _health.Value - damage);
        }
    }
}
