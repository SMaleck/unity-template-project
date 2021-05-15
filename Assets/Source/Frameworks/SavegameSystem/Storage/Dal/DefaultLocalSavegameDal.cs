using Source.Frameworks.Logging;
using Source.Frameworks.SavegameSystem.Config;
using System.IO;

namespace Source.Frameworks.SavegameSystem.Storage.Dal
{
    public class DefaultLocalSavegameDal : ISavegameReader, ISavegameWriter
    {
        private readonly ISavegameLogger _logger;
        private readonly string _filePath;

        public DefaultLocalSavegameDal(
            ISavegameLogger logger,
            ISavegameConfig savegameConfig)
        {
            _logger = logger;

            var basePath = UnityEngine.Application.persistentDataPath;
            _filePath = Path.Combine(basePath, savegameConfig.Filename);
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
