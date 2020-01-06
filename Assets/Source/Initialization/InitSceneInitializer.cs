using UGF.Services.SceneManagement;
using Zenject;

namespace Source.Initialization
{
    public class InitSceneInitializer : IInitializable
    {
        [Inject] private readonly ISceneManagementService _sceneManagementService;

        public void Initialize()
        {
            _sceneManagementService.ToTitle();
        }
    }
}
