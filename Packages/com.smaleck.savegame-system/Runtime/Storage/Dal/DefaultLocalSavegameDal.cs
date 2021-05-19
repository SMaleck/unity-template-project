using System.IO;
using SavegameSystem.Logging;
using SavegameSystem.Settings;

namespace SavegameSystem.Storage.Dal
{
    public class DefaultLocalSavegameDal : ISavegameReader, ISavegameWriter
    {
        private readonly ISavegameLogger _logger;
        private readonly string _filePath;

        public DefaultLocalSavegameDal(
            ISavegameLogger logger,
            ISavegameSettings savegameSettings)
        {
            _logger = logger;

            var basePath = UnityEngine.Application.persistentDataPath;
            _filePath = Path.Combine(basePath, savegameSettings.Filename);
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
