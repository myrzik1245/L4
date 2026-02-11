using Assets._Project.Code.Runtime.Infrastructure.Registrations;
using Assets._Project.Code.Runtime.Utility.ConfigManagment;
using Assets._Project.Code.Runtime.Utility.CoroutineManagment;
using Assets._Project.Develop.Infrastructure.DI;
using Assets._Project.Develop.Utility.LoadScreen;
using Assets._Project.Develop.Utility.SceneManagment;
using System.Collections;
using UnityEngine;

namespace Assets._Project.Develop.Infrastructure.EntryPoint
{
    public class EntryPoint : MonoBehaviour
    {
        private void Awake()
        {
            DIContainer projectContainer = new DIContainer();

            ProjectRegistrations.Register(projectContainer);

            projectContainer.Resolve<ICoroutinePerformer>().StartPerform(Initialize(projectContainer));
        }

        private IEnumerator Initialize(DIContainer container)
        {
            ILoadScreen loadScreen = container.Resolve<ILoadScreen>();
            loadScreen.Show();

            ConfigsProvider configsProvider = container.Resolve<ConfigsProvider>();
            LoadSceneService loadSceneService = container.Resolve<LoadSceneService>();

            yield return configsProvider.LoadAsync();
            yield return loadSceneService.LoadAsync(Scenes.Gameplay);

            loadScreen.Hide();
        }
    }
}