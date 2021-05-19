using SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem.Creation
{
    public interface ISavegameMetaDataFactory
    {
        SavegameMetaData Create();
    }
}