namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Write
{
    public interface ISavegameWriteMiddleware : ISavegameStorageMiddleware
    {
        string Process(string savegameJson);
    }
}
