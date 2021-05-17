using Source.Services.SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem.Creation
{
    public interface ISavegameContentFactory
    {
        SavegameContent Create();
    }
}
