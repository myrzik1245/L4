using Assets._Project.Code.Runtime.Gameplay.Entities;
using Assets._Project.Code.Runtime.Gameplay.EntitiesCore;
using Assets._Project.Code.Runtime.Gameplay.Factories;
using Assets._Project.Code.Runtime.Infrastructure.Registrations;
using Assets._Project.Code.Runtime.Utility.AssetsManagment;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Infrastructure.EntryPoint;
using Assets._Project.Develop.Utility.SceneManagment.SceneInputArgs;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Code.Infrastructure.EntryPoints
{
    public class GameplayEntryPoint : SceneEntryPoint
    {
        private EntityLifeContext _lifeContext;

        public override IEnumerator Initialize(DIContainer container, IInputSceneArgs inputSceneArgs = null)
        {
            GameplayRegistrations.Register(container);

            _lifeContext = container.Resolve<EntityLifeContext>();

            EntitiesFactory entitiesFactory = container.Resolve<EntitiesFactory>();
            MonoEntitiesFactory monoEntitiesFactory = container.Resolve<MonoEntitiesFactory>();
            ResourcesAssetsLoader resourcesAssetsLoader = container.Resolve<ResourcesAssetsLoader>();

            Entity teleportationEntity = entitiesFactory.CreateTeleportationCharacter();

            MonoEntity rigidbodyPrefab
                = resourcesAssetsLoader.Load<MonoEntity>("Gameplay/MonoEntities/RigidbodyEntity");

            MonoEntity monoRigidbodyPlayer
                = monoEntitiesFactory.Create(teleportationEntity, Vector3.right, rigidbodyPrefab);

            _lifeContext.Add(teleportationEntity);

            yield break;
        }

        public override IEnumerator Run()
        {
            yield break;
        }

        private void Update()
        {
            _lifeContext?.Update(Time.deltaTime);
        }

        private void OnDestroy()
        {
            _lifeContext.Dispose();
        }
    }
}