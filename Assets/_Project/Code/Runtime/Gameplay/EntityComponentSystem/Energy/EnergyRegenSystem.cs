using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using System;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Energy
{
    public class EnergyRegenSystem : IEntitySystem, IInitializableSystem, IUpdatableSystem
    {
        private ReactiveVariable<int> _energy;
        private ReactiveVariable<int> _maxEnergy;
        private ReactiveVariable<int> _regenPercent;
        private ReactiveVariable<float> _regenCooldown;

        private float _time;

        public void Initialize(Entity entity)
        {
            _energy = entity.Energy;
            _maxEnergy = entity.MaxEnergy;
            _regenPercent = entity.EnergyRegenPercent;
            _regenCooldown = entity.EnergyRegenCooldown;
        }

        public void Update(float deltaTime)
        {
            _time += deltaTime;

            if (_time >= _regenCooldown.Value)
            {
                _time = 0;
                _energy.Value = Math.Clamp(_maxEnergy.Value / _regenPercent.Value, 0, _maxEnergy.Value);
            }
        }
    }
}