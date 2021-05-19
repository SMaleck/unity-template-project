using SavegameSystem.Serializable;
using SavegameSystem.Storage;

namespace Source.Services.SavegameSystem.Creation
{
    public class SavegameMetaDataFactory : ISavegameMetaDataFactory
    {
        private readonly ISavegameTimeProvider _savegameTimeProvider;

        public SavegameMetaDataFactory(ISavegameTimeProvider savegameTimeProvider)
        {
            _savegameTimeProvider = savegameTimeProvider;
        }

        public SavegameMetaData Create()
        {
            return new SavegameMetaData()
            {
                Version = 0,
                CreatedAtUtc = _savegameTimeProvider.UtcNow,
                UpdatedAtUtc = _savegameTimeProvider.UtcNow,
                CreatedAtClientVersion = "",
                CreatedAtClientBuild = "",
                ClientVersion = "",
                ClientBuild = ""
            };
        }
    }
}
