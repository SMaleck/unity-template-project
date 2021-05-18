using SavegameSystem.Serializable;
using SavegameSystem.Storage;
using Source.Services.SavegameSystem.Creation;
using Source.Services.SavegameSystem.Serializable;
using UtilitiesGeneral.Logging;

namespace Source.Services.SavegameSystem
{
    public class SavegameService : ISavegameService
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

        public ISavegame<SavegameContent> Load()
        {
            if (!_savegameStorage.TryLoad(out _savegame))
            {
                _logger.Warn("Failed to load Savegame. Creating new one.");

                _savegame = _savegameFactory.Create();
                Save();
            }

            return _savegame;
        }

        public void Save()
        {
            _savegameStorage.TrySave(_savegame);
        }
    }
}
