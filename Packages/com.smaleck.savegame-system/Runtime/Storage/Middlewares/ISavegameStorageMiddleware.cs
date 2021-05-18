namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares
{
    public interface ISavegameStorageMiddleware
    {
        public int ExecutionOrder { get; }
    }
}
