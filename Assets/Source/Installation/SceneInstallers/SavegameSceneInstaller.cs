using Source.Services.Savegames;
using Source.Services.Savegames.Models;
using Source.Services.SceneManagement;
using Zenject;

namespace Source.Installation.SceneInstallers
{
    public class SavegameSceneInstaller : MonoInstaller
    {
        [Inject] private readonly ISceneManagementService _sceneManagementService;
        [Inject] private readonly ISavegameService _savegameService;

        public override void InstallBindings()
        {
            var savegame = _savegameService.Savegame;
            Container.BindInterfacesAndSelfTo<Savegame>().FromInstance(savegame);

            _sceneManagementService.ToTitle();
        }
    }
}
