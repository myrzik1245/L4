using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using System;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Health
{
    public class ClampHealthSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<int> _health;
        private ReactiveVariable<int> _maxHealth;

        public void Initialize(Entity entity)
        {
            _health = entity.Health;
            _maxHealth = entity.MaxHealth;
        }

        public void Update(float deltaTime)
        {
            _health.Value = Math.Clamp(_health.Value, 0, _maxHealth.Value);
        }
    }
}
