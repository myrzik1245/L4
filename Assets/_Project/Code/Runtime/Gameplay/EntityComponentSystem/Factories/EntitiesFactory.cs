using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Damage;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Energy;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Health;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
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

        public Entity CreateTeleportationCharacter()
        {
            Entity entity = CreateEmptyEntity();

            ICondition removeCondition = new CompositeCondition(
                new FuncCondition(() => entity.IsAlive.Value == false));

            ICondition teleportCondition = new CompositeCondition(
                new FuncCondition(() => entity.IsAlive.Value),
                new FuncCondition(() => entity.Energy.Value >= 20));

            entity.AddIsAlive(new ReactiveVariable<bool>(true))
                .AddHealth(new ReactiveVariable<int>(100))
                .AddMaxHealth(new ReactiveVariable<int>(100))
                .AddEnergy(new ReactiveVariable<int>(100))
                .AddMaxEnergy(new ReactiveVariable<int>(100))
                .AddEnergyRegenPercent(new ReactiveVariable<int>(10))
                .AddEnergyRegenCooldown(new ReactiveVariable<float>(5))
                .AddTeleportRequest(new ReactiveEvent())
                .AddTeleportRadius(new ReactiveVariable<float>(3))
                .AddTeleportEvent(new ReactiveEvent<Vector3>())
                .AddTeleportSpendEnergy(new ReactiveVariable<int>(20))
                .AddAttackRadius(new ReactiveVariable<float>(5))
                .AddDamage(new ReactiveVariable<int>(10))
                .AddDamageRequest(new ReactiveEvent<int>());

            entity.AddSystem(new RemoveSelfSystem(removeCondition, _container.Resolve<EntityLifeContext>()))
                .AddSystem(new AliveSystem())
                .AddSystem(new ClampHealthSystem())
                .AddSystem(new ClampEnergySystem())
                .AddSystem(new EnergyRegenSystem())
                .AddSystem(new TeleportInputSystem(_container.Resolve<IInputService>()))
                .AddSystem(new TeleportSystem(
                    new RadiusPositionRandomizer(entity.TeleportRadius.Value),
                    teleportCondition))
                .AddSystem(new SpendEnergyOnTeleportSystem())
                .AddSystem(new AttackOnTeleportSystem())
                .AddSystem(new TakeDamageSystem());

            return entity;
        }

        public Entity CreateTarget()
        {
            Entity entity = CreateEmptyEntity();

            ICondition removeCondition = new CompositeCondition(
                new FuncCondition(() => entity.IsAlive.Value == false));

            entity.AddIsAlive(new ReactiveVariable<bool>(true))
                .AddHealth(new ReactiveVariable<int>(20))
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
