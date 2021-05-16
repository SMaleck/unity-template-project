namespace Source.Frameworks.SavegameSystem.Storage.Middlewares
{
    public interface ISavegameStorageMiddleware
    {
        public int ExecutionOrder { get; }
    }
}
