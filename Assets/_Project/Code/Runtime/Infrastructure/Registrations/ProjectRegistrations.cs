using Assets._Project.Code.Runtime.Utility.AssetsManagment;
using Assets._Project.Code.Runtime.Utility.ConfigManagment;
using Assets._Project.Code.Runtime.Utility.ConfigManagment.Loaders;
using Assets._Project.Code.Runtime.Utility.CoroutineManagment;
using Assets._Project.Code.Utility.InputService;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Utility.LoadScreen;
using Assets._Project.Develop.Utility.SceneManagment;
using UnityEngine;
using UnityEngine.Rendering;

namespace Assets._Project.Code.Runtime.Infrastructure.Registrations
{
    public class ProjectRegistrations
    {
        public static void Register(DIContainer projectContatiner)
        {
            projectContatiner.Register(CreateCoroutinePerformer).AsSingle();
            projectContatiner.Register(CreateLoadingScreen).AsSingle();
            projectContatiner.Register(CreateResurcesAssetsLoader).AsSingle();
            projectContatiner.Register(CreateLoadSceneService).AsSingle();
            projectContatiner.Register(CreateConfigsProvider).AsSingle();

            projectContatiner.Initialize();
        }

        private static ConfigsProvider CreateConfigsProvider(DIContainer c)
        {
            return new ConfigsProvider(
                new ResourcesConfigLoader(c.Resolve<ResourcesAssetsLoader>()));
        }

        private static LoadSceneService CreateLoadSceneService(DIContainer c)
        {
            return new LoadSceneService(
                c.Resolve<ILoadScreen>(),
                c);
        }

        private static ResourcesAssetsLoader CreateResurcesAssetsLoader(DIContainer c)
        {
            return new ResourcesAssetsLoader();
        }

        private static ILoadScreen CreateLoadingScreen(DIContainer c)
        {
            ResourcesAssetsLoader resourceLoader = c.Resolve<ResourcesAssetsLoader>();

            LoadScreen loadScreenPrefab = resourceLoader.Load<LoadScreen>("Utility/LoadScreen");
            LoadScreen loadScreen = GameObject.Instantiate(loadScreenPrefab);

            return loadScreen;
        }

        private static ICoroutinePerformer CreateCoroutinePerformer(DIContainer c)
        {
            ResourcesAssetsLoader resourceLoader = c.Resolve<ResourcesAssetsLoader>();
            CoroutinePerformer coroutinePerformerPrefab 
                = resourceLoader.Load<CoroutinePerformer>("Utility/CoroutinePerformer");

            return GameObject.Instantiate(coroutinePerformerPrefab);
        }
    }
}