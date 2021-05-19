using SavegameSystem.Serializable;
using Source.Services.SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem.Creation
{
    public class SavegameFactory : ISavegameFactory
    {
        private readonly ISavegameMetaDataFactory _metaDataFactory;
        private readonly ISavegameContentFactory _contentFactory;

        public SavegameFactory(
            ISavegameMetaDataFactory metaDataFactory,
            ISavegameContentFactory contentFactory)
        {
            _metaDataFactory = metaDataFactory;
            _contentFactory = contentFactory;
        }

        public ISavegame<SavegameContent> Create()
        {
            return new Savegame<SavegameContent>()
            {
                MetaData = _metaDataFactory.Create(),
                Content = _contentFactory.Create()
            };
        }
    }
}
