using Source.Frameworks.SavegameSystem.Runtime.Config;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares
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
