using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitySystems;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using System;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport
{
    public class SpendEnergyOnTeleportSystem : IEntitySystem, IInitializableSystem, IDisposable
    {
        private ReactiveVariable<int> _energy;
        private ReactiveVariable<int> _maxEnergy;
        private ReactiveVariable<int> _spendEnergyOnTeleport;

        private IDisposable _teleportEventDisposable;

        public void Initialize(Entity entity)
        {
            _energy = entity.Energy;
            _maxEnergy = entity.MaxEnergy;
            _spendEnergyOnTeleport = entity.TeleportSpendEnergy;

            _teleportEventDisposable = entity.TeleportEvent.Subscribe(OnTeleport);
        }

        public void Dispose()
        {
            _teleportEventDisposable.Dispose();
        }

        private void OnTeleport(Vector3 vector)
        {
            _energy.Value = Mathf.Clamp(_energy.Value - _spendEnergyOnTeleport.Value, 0, _maxEnergy.Value);
        }
    }
}
