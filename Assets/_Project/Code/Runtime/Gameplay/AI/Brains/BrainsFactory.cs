using _Project.Code.Runtime.Gameplay.AI.States;
using _Project.Code.Runtime.Gameplay.AI.TargetSelector;
using _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
using Assets._Project.Code.Runtime.Utility.Conditions;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Develop.Infrastructure.DI;

namespace _Project.Code.Runtime.Gameplay.AI.Brains
{
    public class BrainsFactory
    {
        private readonly DIContainer _container;

        private BrainsContext BrainsContext => _container.Resolve<BrainsContext>();

        public BrainsFactory(DIContainer container)
        {
            _container = container;
        }

        public Brain CreateSmartTeleportBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateSmartTeleportationStateMachine(entity);

            return CreateAIStateMachineBrain(entity, stateMachine);
        }

        public Brain CreateRandomTeleportBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomTeleportStateMachine(entity);

            return CreateAIStateMachineBrain(entity, stateMachine);
        }

        public Brain CreatePlayerBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateInputTeleportStateMachine(entity);

            return CreateAIStateMachineBrain(entity, stateMachine);
        }

        private Brain CreateAIStateMachineBrain(Entity entity, AIStateMachine stateMachine)
        {
            Brain brain = new StateMachineBrain(stateMachine);
            BrainsContext.Add(entity, brain);

            return brain;
        }

        private AIStateMachine CreateSmartTeleportationStateMachine(Entity entity)
        {
            AIStateMachine rootStateMachine = new AIStateMachine();

            AIStateMachine passiveState = CreatePassiveStateMachine(entity);
            TeleportToTargetState teleportToTargetState = new TeleportToTargetState(
                entity,
                _container.Resolve<EntityLifeContext>(),
                new MinHpSelector(entity),
                1);

            ICondition teleportToPassive = new CompositeCondition(
                LogicOperation.Or,
                new FuncCondition(() => entity.Energy.Value < 40),
                new FuncCondition(() => teleportToTargetState.Target == null));

            ICondition passiveToTeleport = new CompositeCondition(
                new FuncCondition(() => entity.Energy.Value >= 40),
                new FuncCondition(() => teleportToTargetState.Target != null));

            rootStateMachine
                .AddState(teleportToTargetState)
                .AddState(passiveState);

            rootStateMachine
                .AddTransition(teleportToTargetState, passiveState, teleportToPassive)
                .AddTransition(passiveState, teleportToTargetState, passiveToTeleport);

            return rootStateMachine;
        }

        private AIStateMachine CreatePassiveStateMachine(Entity entity)
        {
            AIStateMachine passiveState = new AIStateMachine();

            AccumulateEnergyState accumulateEnergyState = new AccumulateEnergyState();
            EmptyState emptyState = new EmptyState();

            ICondition accumulateToEmpty = new CompositeCondition(
                new FuncCondition(() => entity.Energy.Value >= 40));

            ICondition emptyToAccumulate = new CompositeCondition(
                new FuncCondition(() => entity.Energy.Value < 40));

            passiveState
                .AddState(accumulateEnergyState)
                .AddState(emptyState);

            passiveState
                .AddTransition(accumulateEnergyState, emptyState, accumulateToEmpty)
                .AddTransition(emptyState, accumulateEnergyState, emptyToAccumulate);

            return passiveState;
        }

        private AIStateMachine CreateRandomTeleportStateMachine(Entity entity)
        {
            AIRandomTeleportationState aiRandomTeleportationState = new AIRandomTeleportationState(
                entity,
                new RadiusPositionRandomizer(entity.TeleportRadius.Value),
                1);

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(aiRandomTeleportationState);

            return stateMachine;
        }

        private AIStateMachine CreateInputTeleportStateMachine(Entity entity)
        {
            InputRandomTeleportationState inputRandomTeleportationState = new InputRandomTeleportationState(
                entity,
                _container.Resolve<IInputService>(),
                new RadiusPositionRandomizer(entity.TeleportRadius.Value));

            AIStateMachine stateMachine = new AIStateMachine();

            stateMachine.AddState(inputRandomTeleportationState);

            return stateMachine;
        }
    }
}
