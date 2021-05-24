using SavegameSystem.Serializable;
using SavegameSystem.Serializable.Creation;
using SavegameSystem.Storage;
using Source.Services.SavegameSystem.Serializable;
using Source.Utilities.Reactive;
using UniRx;
using UtilitiesGeneral.Logging;
using Zenject;

namespace Source.Services.SavegameSystem
{
    public class SavegameService : AbstractDisposable, ISavegameService, IInitializable
    {
        private readonly ILogger _logger;
        private readonly ISavegameFactory _savegameFactory;
        private readonly ISavegameStorage _savegameStorage;

        private ISavegame<SavegameContent> _savegame;

        public SavegameService(
            ILogger logger,
            ISavegameFactory savegameFactory,
            ISavegameStorage savegameStorage)
        {
            _logger = logger;
            _savegameFactory = savegameFactory;
            _savegameStorage = savegameStorage;
        }

        public void Initialize()
        {
            Observable.OnceApplicationQuit()
                .Subscribe(_ => Save())
                .AddTo(Disposer);
        }

        public ISavegame<SavegameContent> Load()
        {
            var loadResult = _savegameStorage.Load<SavegameContent>();
            if (!loadResult.Success)
            {
                _logger.Warn("Failed to load Savegame. Creating new one.");

                _savegame = _savegameFactory.Create<SavegameContent>();
                Save();
            }

            return _savegame;
        }

        public void Save()
        {
            var saveResult = _savegameStorage.Save(_savegame);
            if (!saveResult.Success)
            {
                _logger.Warn("Failed to save Savegame.");
                _logger.Error(saveResult.Exception);
            }
        }
    }
}
