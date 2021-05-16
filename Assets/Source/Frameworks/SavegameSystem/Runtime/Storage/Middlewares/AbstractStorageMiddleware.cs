using Source.Frameworks.SavegameSystem.Config;

namespace Source.Frameworks.SavegameSystem.Storage.Middlewares
{
    public abstract class AbstractStorageMiddleware : ISavegameStorageMiddleware
    {
        public int ExecutionOrder { get; }

        protected AbstractStorageMiddleware(int executionOrder = SavegameConstants.DefaultExecutionOrder)
        {
            ExecutionOrder = executionOrder;
        }
    }
}
