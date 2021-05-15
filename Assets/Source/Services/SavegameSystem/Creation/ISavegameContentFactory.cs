using Source.Services.SavegameSystem.Serialization;

namespace Source.Services.SavegameSystem.Creation
{
    public interface ISavegameContentFactory
    {
        SavegameContent Create();
    }
}
