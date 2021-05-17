using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PostRead
{
    public interface ISavegamePostReadMiddleware : ISavegameStorageMiddleware
    {
        ISavegame<T> Process<T>(ISavegame<T> savegame);
    }
}
