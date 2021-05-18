namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Read
{
    public interface ISavegameReadMiddleware : ISavegameStorageMiddleware
    {
        string Process(string savegameJson);
    }
}
