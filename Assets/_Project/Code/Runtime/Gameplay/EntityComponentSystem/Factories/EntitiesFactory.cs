using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Energy;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Health;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Systems;
using Assets._Project.Code.Runtime.Utility.Conditions;
using Assets._Project.Code.Runtime.Utility.Reactive.Variable;
using Assets._Project.Develop.Infrastructure.DI;

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

            entity.AddIsAlive(new ReactiveVariable<bool>(true))
                .AddHealth(new ReactiveVariable<int>(100))
                .AddMaxHealth(new ReactiveVariable<int>(100))
                .AddEnergy(new ReactiveVariable<int>(100))
                .AddMaxEnergy(new ReactiveVariable<int>(100))
                .AddEnergyRegenPercent(new ReactiveVariable<int>(10))
                .AddEnergyRegenCooldown(new ReactiveVariable<float>(1));

            entity.AddSystem(new RemoveSelfSystem(removeCondition, _container.Resolve<EntityLifeContext>()))
                .AddSystem(new AliveSystem())
                .AddSystem(new ClampHealthSystem())
                .AddSystem(new ClampEnergySystem())
                .AddSystem(new EnergyRegenSystem());

            return entity;
        }

        public Entity CreateEmptyEntity()
        {
            return new Entity();
        }
    }
}
