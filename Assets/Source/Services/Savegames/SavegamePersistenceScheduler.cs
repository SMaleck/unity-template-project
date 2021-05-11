using Source.Frameworks.SavegameSystem;
using Source.Services.SceneManagement;
using Source.Utilities.Reactive;
using UniRx;
using Zenject;

namespace Source.Services.Savegames
{
    public class SavegamePersistenceScheduler : AbstractDisposable, IInitializable
    {
        private readonly ISavegameService _savegameService;
        private readonly ISceneManagementService _sceneManagementService;

        public SavegamePersistenceScheduler(
            ISavegameService savegameService,
            ISceneManagementService sceneManagementService)
        {
            _savegameService = savegameService;
            _sceneManagementService = sceneManagementService;
        }

        public void Initialize()
        {
            _savegameService.Load();

            _sceneManagementService.OnSceneLoadStarted
                .Subscribe(_ => _savegameService.EnqueueSaveRequest())
                .AddTo(Disposer);

            Observable.OnceApplicationQuit()
                .Subscribe(_ => _savegameService.Save())
                .AddTo(Disposer);
        }
    }
}
