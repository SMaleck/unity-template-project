using Source.Frameworks.SavegameSystem.Serializable;
using Source.Services.SavegameSystem;
using Source.Services.SavegameSystem.Serialization;
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
            var savegame = _savegameService.Load();

            Container.BindInterfacesAndSelfTo<Savegame<SavegameContent>>().FromInstance(savegame);

            _sceneManagementService.ToTitle();
        }
    }
}
