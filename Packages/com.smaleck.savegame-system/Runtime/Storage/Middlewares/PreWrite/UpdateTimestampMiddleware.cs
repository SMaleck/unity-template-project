using SavegameSystem.Serializable;

namespace SavegameSystem.Storage.Middlewares.PreWrite
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
            savegame.MetaData.UpdatedAtUtc = _timeProvider.UtcNow;

            return savegame;
        }
    }
}
