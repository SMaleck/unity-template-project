﻿namespace Source.Frameworks.SavegameSystem.Storage.Middlewares.Read
{
    public interface ISavegameReadMiddleware : ISavegameStorageMiddleware
    {
        string Process(string savegameJson);
    }
}
