using _Project.Code.Runtime.Gameplay.AI.States;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntityComponentSystem.Teleport.PositionRandomiser;
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

        public Brain CreateTeleportBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateRandomTeleportStateMachine(entity);
            Brain brain = new StateMachineBrain(stateMachine);
            BrainsContext.Add(entity, brain);

            return brain;
        }

        public Brain CreatePlayerBrain(Entity entity)
        {
            AIStateMachine stateMachine = CreateInputTeleportStateMachine(entity);
            Brain brain = new StateMachineBrain(stateMachine);
            BrainsContext.Add(entity, brain);

            return brain;
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
