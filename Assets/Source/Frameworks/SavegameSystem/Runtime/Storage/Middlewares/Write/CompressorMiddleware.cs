using Source.Frameworks.SavegameSystem.Config;

namespace Source.Frameworks.SavegameSystem.Storage.Middlewares.Write
{
    public class CompressorMiddleware : AbstractStorageMiddleware, ISavegameWriteMiddleware
    {
        public CompressorMiddleware() 
            : base(SavegameConstants.CompressorExecutionOrder)
        {
        }

        // ToDo SAVE Implement CompressorWriteMiddleware
        public string Process(string savegameJson)
        {
            return savegameJson;
        }
    }
}
