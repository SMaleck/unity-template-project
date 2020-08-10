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
            var savegameData = _savegameService.Load();
            var savegame = new Savegame(savegameData);

            Container.BindInterfacesAndSelfTo<Savegame>().FromInstance(savegame);

            _sceneManagementService.ToTitle();
        }
    }
}
