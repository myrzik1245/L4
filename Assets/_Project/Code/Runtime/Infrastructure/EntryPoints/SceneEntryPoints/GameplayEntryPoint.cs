using _Project.Code.Runtime.Utility.Update;
using Assets._Project.Code.Runtime.Configs.Characters;
using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.Factories;
using Assets._Project.Code.Runtime.Infrastructure.Registrations;
using Assets._Project.Code.Runtime.Utility.AssetsManagment;
using Assets._Project.Code.Runtime.Utility.ConfigManagment;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.EntryPoint;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections;
using UnityEngine;

namespace _Project.Code.Runtime.Infrastructure.EntryPoints.SceneEntryPoints
{
    public class GameplayEntryPoint : SceneEntryPoint
    {
        private EntityLifeContext _lifeContext;
        private IUpdatableService _updatableService;

        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs = null)
        {
            GameplayRegistrations.Register(container);

            _lifeContext = container.Resolve<EntityLifeContext>();
            _updatableService = container.Resolve<IUpdatableService>();

            EntitiesFactory entitiesFactory = container.Resolve<EntitiesFactory>();
            MonoEntitiesFactory monoEntitiesFactory = container.Resolve<MonoEntitiesFactory>();
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();
            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();

            Entity teleportEntity
                = entitiesFactory.CreateTeleportationCharacter(configsProvider.GetConfig<TeleportCharacter>());

            Entity target
                = entitiesFactory.CreateTarget(configsProvider.GetConfig<TargetCharacter>());

            MonoEntity teleporCharacterPrefab
                = resourcesAssetsLoader.Load<MonoEntity>("Gameplay/MonoEntities/TeleportCharacter");

            MonoEntity targetCharacter
                = resourcesAssetsLoader.Load<MonoEntity>("Gameplay/MonoEntities/TargetCharacter");

            MonoEntity teleportCharacter
                = monoEntitiesFactory.Create(teleportEntity, Vector3.right, teleporCharacterPrefab);

            MonoEntity rigidbodyTarget
                = monoEntitiesFactory.Create(target, Vector3.left, teleporCharacterPrefab);

            _lifeContext.Add(teleportEntity);
            _lifeContext.Add(target);

            _updatableService.AddRequest(_lifeContext);

            yield break;
        }

        public override IEnumerator Run()
        {
            yield break;
        }

        private void OnDestroy()
        {
            _lifeContext.Dispose();
            _updatableService.RemoveRequest(_lifeContext);
        }
    }
}