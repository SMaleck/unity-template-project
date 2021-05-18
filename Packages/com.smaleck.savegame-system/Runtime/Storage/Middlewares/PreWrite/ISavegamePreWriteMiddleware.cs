using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PreWrite
{
    public interface ISavegamePreWriteMiddleware : ISavegameStorageMiddleware
    {
        ISavegame<T> Process<T>(ISavegame<T> savegame);
    }
}
