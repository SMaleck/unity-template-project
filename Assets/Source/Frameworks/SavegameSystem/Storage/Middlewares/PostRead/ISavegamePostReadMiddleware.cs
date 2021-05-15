using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage.Middlewares.PostRead
{
    public interface ISavegamePostReadMiddleware : ISavegameStorageMiddleware
    {
        ISavegame Process(ISavegame savegame);
    }
}
