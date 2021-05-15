using Source.Frameworks.SavegameSystem.Serializable;
using Source.Frameworks.SavegameSystem.Storage.Middlewares.Write;

namespace Source.Frameworks.SavegameSystem.Storage.Middlewares.PreWrite
{
    public class UpdateTimestampMiddleware : AbstractStorageMiddleware, ISavegamePreWriteMiddleware
    {
        private readonly ISavegameTimeProvider _timeProvider;
        
        public UpdateTimestampMiddleware(ISavegameTimeProvider timeProvider) 
        {
            _timeProvider = timeProvider;
        }

        public ISavegame Process(ISavegame savegame)
        {
            savegame.UpdatedAtUtc = _timeProvider.UtcNow;

            return savegame;
        }
    }
}
