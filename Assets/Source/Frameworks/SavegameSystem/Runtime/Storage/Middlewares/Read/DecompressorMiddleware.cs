using Source.Frameworks.SavegameSystem.Runtime.Config;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Read
{
    public class DecompressorMiddleware : AbstractStorageMiddleware, ISavegameReadMiddleware
    {
        public DecompressorMiddleware() 
            : base(SavegameConstants.DecompressorExecutionOrder)
        {
        }

        // ToDo SAVE Implement DecompressorMiddleware
        public string Process(string savegameJson)
        {
            return savegameJson;
        }
    }
}
