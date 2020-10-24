using Source.Services.SceneManagement;
using Zenject;

namespace Source.Installation.SceneInstallers
{
    public class InitSceneInstaller : MonoInstaller
    {
        [Inject] private readonly ISceneManagementService _sceneManagementService;

        public override void InstallBindings()
        {
            _sceneManagementService.Startup();
        }
    }
}
