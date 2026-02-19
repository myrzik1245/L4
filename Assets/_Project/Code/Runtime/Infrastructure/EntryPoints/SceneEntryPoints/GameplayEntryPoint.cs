using _Project.Code.Runtime.Gameplay.AI.Brains;
using _Project.Code.Runtime.Gameplay.EntityComponentSystem.Core;
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
        private IUpdatableService _updatableService;
        private EntityLifeContext _entityLifeContext;
        private BrainsContext _brainsContext;
        private EntitiesFactory _entitiesFactory;
        private ConfigsProvider _configsProvider;
        private ResourcesAssetsLoader _resourcesAssetsLoader;
        private MonoEntitiesFactory _monoEntitiesFactory;

        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs = null)
        {
            GameplayRegistrations.Register(container);

            _entityLifeContext = container.Resolve<EntityLifeContext>();
            _updatableService = container.Resolve<IUpdatableService>();
            _entitiesFactory = container.Resolve<EntitiesFactory>();
            _configsProvider = container.Resolve<ConfigsProvider>();
            _resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();
            _monoEntitiesFactory = container.Resolve<MonoEntitiesFactory>();
            _brainsContext = container.Resolve<BrainsContext>();

            BrainsFactory brainsFactory = container.Resolve<BrainsFactory>();

            Entity teleportEntity = CreateTeleportCharacter(Vector3.right);
            Entity targetEntity = CreateTargetCharacter(Vector3.left);

            brainsFactory.CreateTeleportBrain(teleportEntity);

            _updatableService.AddRequest(_entityLifeContext);
            _updatableService.AddRequest(_brainsContext);

            yield break;
        }

        public override IEnumerator Run()
        {
            yield break;
        }

        private void OnDestroy()
        {
            _entityLifeContext.Dispose();
            _updatableService.RemoveRequest(_entityLifeContext);

            _brainsContext.Dispose();
            _updatableService.RemoveRequest(_brainsContext);
        }

        private Entity CreateTeleportCharacter(Vector3 position)
        {
            Entity teleportEntity
                = _entitiesFactory.CreateTeleportationCharacter(_configsProvider.GetConfig<TeleportCharacter>());

            MonoEntity teleporCharacterPrefab
                = _resourcesAssetsLoader.Load<MonoEntity>("Gameplay/MonoEntities/TeleportCharacter");

            _monoEntitiesFactory.Create(teleportEntity, position, teleporCharacterPrefab);

            _entityLifeContext.Add(teleportEntity);

            return teleportEntity;
        }

        private Entity CreateTargetCharacter(Vector3 position)
        {
            Entity target
                = _entitiesFactory.CreateTarget(_configsProvider.GetConfig<TargetCharacter>());

            MonoEntity targetCharacterPrefab
                = _resourcesAssetsLoader.Load<MonoEntity>("Gameplay/MonoEntities/TargetCharacter");

            _monoEntitiesFactory.Create(target, position, targetCharacterPrefab);
            
            _entityLifeContext.Add(target);

            return target;
        }
    }
}