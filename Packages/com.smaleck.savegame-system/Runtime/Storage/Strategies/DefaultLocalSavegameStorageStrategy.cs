using System.IO;
using SavegameSystem.Logging;
using SavegameSystem.Settings;

namespace SavegameSystem.Storage.Strategies
{
    public class DefaultLocalSavegameStorageStrategy : ISavegameStorageStrategy
    {
        private readonly ISavegameLogger _logger;
        private readonly string _filePath;

        // ToDo SAVE Replace Settings dependency with a path provider
        public DefaultLocalSavegameStorageStrategy(
            ISavegameLogger logger,
            ISavegameSettings savegameSettings)
        {
            _logger = logger;

            _filePath = Path.Combine(savegameSettings.Path, savegameSettings.Filename);
        }

        public string Read()
        {
            _logger.Log($"Reading savegame from {_filePath}");

            if (!File.Exists(_filePath))
            {
                return string.Empty;
            }

            return File.ReadAllText(_filePath);
        }

        public void Write(string serializedSavegame)
        {
            _logger.Log($"Writing savegame to {_filePath}");

            var directory = Path.GetDirectoryName(_filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(_filePath, serializedSavegame);
        }
    }
}
