using _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core;
using Assets._Project.Code.Runtime.Configs.Characters;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Damage;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Energy;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Health;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.TeleportApplySystems;
using Assets._Project.Code.Runtime.Utility.Conditions;
using Assets._Project.Code.Runtime.Utility.Reactive.Event;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Develop.Infrastructure.DI;
using UnityEngine;

namespace Assets._Project.Code.Runtime.Gameplay.Factories
{
    public class EntitiesFactory
    {
        private readonly DIContainer _container;

        public EntitiesFactory(DIContainer container)
        {
            _container = container;
        }

        public Entity CreateTeleportationCharacter(TeleportCharacter config)
        {
            Entity entity = CreateEmptyEntity();


            entity.AddIsAlive(new ReactiveVariable<bool>(true))
                .AddHealth(new ReactiveVariable<int>(config.Health))
                .AddMaxHealth(new ReactiveVariable<int>(config.MaxHealth))
                .AddEnergy(new ReactiveVariable<int>(config.Energy))
                .AddMaxEnergy(new ReactiveVariable<int>(config.MaxEnergy))
                .AddEnergyRegenPercent(new ReactiveVariable<int>(config.EnergyRegenPercent))
                .AddEnergyRegenCooldown(new ReactiveVariable<float>(config.EnergyRegenCooldown))
                .AddTeleportRequest(new ReactiveEvent<Vector3>())
                .AddTeleportRadius(new ReactiveVariable<float>(config.TeleportRadius))
                .AddTeleportEvent(new ReactiveEvent<Vector3>())
                .AddTeleportSpendEnergy(new ReactiveVariable<int>(config.TeleportSpendEnergy))
                .AddAttackRadius(new ReactiveVariable<float>(config.AttackRadius))
                .AddDamage(new ReactiveVariable<int>(config.Damage))
                .AddDamageRequest(new ReactiveEvent<int>());

            ICondition removeCondition = new CompositeCondition(
                new FuncCondition(() => entity.IsAlive.Value == false));

            ICondition teleportCondition = new CompositeCondition(
                new FuncCondition(() => entity.IsAlive.Value),
                new FuncCondition(() => entity.Energy.Value >= config.TeleportSpendEnergy));

            entity.AddSystem(new RemoveSelfSystem(removeCondition, _container.Resolve<EntityLifeContext>()))
                .AddSystem(new AliveSystem())
                .AddSystem(new ClampHealthSystem())
                .AddSystem(new ClampEnergySystem())
                .AddSystem(new EnergyRegenSystem())
                .AddSystem(new TeleportInputSystem(
                    _container.Resolve<IInputService>(),
                    new RadiusPositionRandomizer(entity.TeleportRadius.Value)))
                .AddSystem(new TransformTeleportApplySystem())
                .AddSystem(new TeleportSystem(teleportCondition))
                .AddSystem(new SpendEnergyOnTeleportSystem())
                .AddSystem(new AttackOnTeleportSystem())
                .AddSystem(new TakeDamageSystem());

            return entity;
        }

        public Entity CreateTarget(TargetCharacter config)
        {
            Entity entity = CreateEmptyEntity();

            ICondition removeCondition = new CompositeCondition(
                new FuncCondition(() => entity.IsAlive.Value == false));

            entity.AddIsAlive(new ReactiveVariable<bool>(true))
                .AddHealth(new ReactiveVariable<int>(config.Health))
                .AddDamageRequest(new ReactiveEvent<int>());

            entity.AddSystem(new RemoveSelfSystem(removeCondition, _container.Resolve<EntityLifeContext>()))
                .AddSystem(new AliveSystem())
                .AddSystem(new TakeDamageSystem());

            return entity;
        }

        public Entity CreateEmptyEntity()
        {
            return new Entity();
        }
    }
}
