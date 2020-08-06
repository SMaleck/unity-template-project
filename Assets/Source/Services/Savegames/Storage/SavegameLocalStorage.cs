using System.IO;
using Source.Framework.Logging;
using Source.Framework.Util.Json;
using Source.Services.Savegames.Config;
using Source.Services.Savegames.Models;

namespace Source.Services.Savegames.Storage
{
    public class SavegameLocalStorage : ISavegameReader, ISavegameWriter
    {
        private readonly string _fullFilePath;

        public SavegameLocalStorage(SavegamesConfig savegamesConfig)
        {
            var basePath = UnityEngine.Application.persistentDataPath;
            _fullFilePath = Path.Combine(basePath, savegamesConfig.SavegameFilename);
        }

        public SavegameData Read()
        {
            Logger.Log($"Loading savegame from {_fullFilePath}");
            var savegameData = JsonStorage.Read<SavegameData>(_fullFilePath);

            return savegameData;
        }

        public void Write(SavegameData savegameData)
        {
            Logger.Log($"Saving savegame to {_fullFilePath}");
            JsonStorage.Write(_fullFilePath, savegameData);
        }
    }
}
