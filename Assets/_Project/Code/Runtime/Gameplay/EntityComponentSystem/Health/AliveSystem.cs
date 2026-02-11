using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Health
{
    public class AliveSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<int> _health;
        private ReactiveVariable<bool> _isAlive;

        public void Initialize(Entity entity)
        {
            _health = entity.Health;
            _isAlive = entity.IsAlive;
        }

        public void Update(float deltaTime)
        {
            if (_health.Value <= 0 && _isAlive.Value)
                _isAlive.Value = false;
        }
    }
}
