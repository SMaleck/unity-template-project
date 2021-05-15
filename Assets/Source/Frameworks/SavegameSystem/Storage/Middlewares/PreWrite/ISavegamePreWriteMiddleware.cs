using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage.Middlewares.Write
{
    public interface ISavegamePreWriteMiddleware : ISavegameStorageMiddleware
    {
        ISavegame Process(ISavegame savegame);
    }
}
