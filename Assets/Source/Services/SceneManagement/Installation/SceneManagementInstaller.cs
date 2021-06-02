using Source.Services.SceneManagement.LoadingScreen;
using Source.Utilities;
using Zenject;

namespace Source.Services.SceneManagement.Installation
{
    public class SceneManagementInstaller : Installer<SceneManagementInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneManagementService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManagementModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingScreenModel>().AsSingle();
            Container.BindPrefabFactory<LoadingScreenView, LoadingScreenView.Factory>();
        }
    }
}
