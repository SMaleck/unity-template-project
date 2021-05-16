using Source.Frameworks.SavegameSystem.Serializable;
using Source.Frameworks.SavegameSystem.Storage;
using Source.Services.SavegameSystem.Serialization;

namespace Source.Services.SavegameSystem.Creation
{
    public class SavegameFactory : ISavegameFactory
    {
        private readonly ISavegameTimeProvider _savegameTimeProvider;
        private readonly ISavegameContentFactory _contentFactory;

        public SavegameFactory(
            ISavegameTimeProvider savegameTimeProvider,
            ISavegameContentFactory contentFactory)
        {
            _savegameTimeProvider = savegameTimeProvider;
            _contentFactory = contentFactory;
        }

        public ISavegame<SavegameContent> Create()
        {
            return new Savegame<SavegameContent>()
            {
                CreatedAtUtc = _savegameTimeProvider.UtcNow,
                UpdatedAtUtc = _savegameTimeProvider.UtcNow,
                Content = _contentFactory.Create()
            };
        }
    }
}
