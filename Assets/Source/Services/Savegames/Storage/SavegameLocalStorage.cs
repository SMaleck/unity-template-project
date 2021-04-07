using System.IO;
using Source.Framework.Logging;
using Source.Framework.Util.Json;
using Source.Packages.SavegameSystem.Config;
using Source.Packages.SavegameSystem.Models;
using Source.Packages.SavegameSystem.Storage;
using Source.Services.Savegames.Models;

namespace Source.Services.Savegames.Storage
{
    public class SavegameLocalStorage : ISavegameReader, ISavegameWriter
    {
        private readonly ILogger _logger;
        private readonly string _fullFilePath;

        public SavegameLocalStorage(
            ILogger logger,
            ISavegameConfig savegameConfig)
        {
            _logger = logger;
            var basePath = UnityEngine.Application.persistentDataPath;
            _fullFilePath = Path.Combine(basePath, savegameConfig.Filename);
        }

        public ISavegameData Read()
        {
            _logger.Log($"Loading savegame from {_fullFilePath}");
            var savegameData = JsonStorage.Read<SavegameData>(_fullFilePath);

            return savegameData;
        }

        public void Write(ISavegameData savegameData)
        {
            _logger.Log($"Saving savegame to {_fullFilePath}");
            JsonStorage.Write(_fullFilePath, savegameData);
        }
    }
}
