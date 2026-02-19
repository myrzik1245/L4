using _Project.Code.Runtime.Gameplay.AI.Brains;
using _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.Factories;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Code.Utility.InputService.Keyboard;
using Assets._Project.Develop.Infrastructure.DI;

namespace Assets._Project.Code.Runtime.Infrastructure.Registrations
{
    public class GameplayRegistrations
    {
        public static void Register(DIContainer gameplayContainer)
        {
            gameplayContainer.Register(CreateInputService).AsSingle();
            gameplayContainer.Register(CreateEntitiesFactory).AsSingle();
            gameplayContainer.Register(CreateEntityLifeContext).AsSingle();
            gameplayContainer.Register(CreateMonoEntityFactory).AsSingle();
            gameplayContainer.Register(CreateBrainsFactory).AsSingle();
            gameplayContainer.Register(CreateBrainContext).AsSingle();

            gameplayContainer.Initialize();
        }

        private static BrainsContext CreateBrainContext(DIContainer c)
        {
            return new BrainsContext();
        }

        private static BrainsFactory CreateBrainsFactory(DIContainer c)
        {
            return new BrainsFactory(c);
        }

        private static MonoEntitiesFactory CreateMonoEntityFactory(DIContainer c)
        {
            return new MonoEntitiesFactory(
                c.Resolve<EntityLifeContext>());
        }

        private static EntityLifeContext CreateEntityLifeContext(DIContainer c)
        {
            return new EntityLifeContext();
        }

        private static EntitiesFactory CreateEntitiesFactory(DIContainer c)
        {
            return new EntitiesFactory(c);
        }

        private static IInputService CreateInputService(DIContainer c)
        {
            return new KeyboardInput();
        }
    }
}