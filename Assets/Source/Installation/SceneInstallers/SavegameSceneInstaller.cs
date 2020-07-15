using Source.Framework.Util.DataStorageStrategies;
using Source.Services.Savegames;
using Source.Services.SceneManagement;
using Zenject;

namespace Source.Installation.SceneInstallers
{
    public class SavegameSceneInstaller : MonoInstaller
    {
        [Inject] private readonly ISceneManagementService _sceneManagementService;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonDataStorageStrategy>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegameService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegamePersistenceScheduler>().AsSingle();

            _sceneManagementService.ToTitle();
        }
    }
}
