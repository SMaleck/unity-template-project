using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PreWrite
{
    public class UpdateTimestampMiddleware : AbstractStorageMiddleware, ISavegamePreWriteMiddleware
    {
        private readonly ISavegameTimeProvider _timeProvider;

        public UpdateTimestampMiddleware(ISavegameTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public ISavegame<T> Process<T>(ISavegame<T> savegame)
        {
            savegame.UpdatedAtUtc = _timeProvider.UtcNow;

            return savegame;
        }
    }
}
