using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using System;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Energy
{
    public class ClampEnergySystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<int> _energy;
        private ReactiveVariable<int> _maxEnergy;

        public void Initialize(Entity entity)
        {
            _energy = entity.Energy;
            _maxEnergy = entity.MaxEnergy;
        }

        public void Update(float deltaTime)
        {
            _energy.Value = Math.Clamp(_energy.Value, 0, _maxEnergy.Value);
        }
    }
}
