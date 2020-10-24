using System.Linq;
using Source.Services.SceneManagement.Config;
using Source.Services.SceneManagement.LoadingScreen;
using Zenject;

namespace Source.Initialization
{
    public class ProjectInitializer : IInitializable
    {
        [Inject] private DiContainer _container;

        [Inject] private SceneManagementConfig _sceneManagementConfig;
        [Inject] private LoadingScreenView.Factory _loadingScreenViewFactory;

        public void Initialize()
        {
            var loadingScreenView = _loadingScreenViewFactory.Create(
                _sceneManagementConfig.LoadingScreenViewPrefab);

            SetupLoadingScreenView(loadingScreenView);
            _container.BindInstance(loadingScreenView);
        }

        protected void SetupLoadingScreenView(LoadingScreenView view)
        {
            view.GetComponents<IInitializable>()
                .Where(viewItem => viewItem.GetType() != typeof(LoadingScreenView))
                .ToList()
                .ForEach(component => component.Initialize());

            view.GetComponentsInChildren<IInitializable>()
                .ToList()
                .ForEach(component => component.Initialize());
        }
    }
}
