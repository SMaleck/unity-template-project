using Source.Frameworks.SavegameSystem.Runtime.Serializable;
using Source.Services.SavegameSystem.Serialization;

namespace Source.Services.SavegameSystem.Creation
{
    public interface ISavegameFactory
    {
        ISavegame<SavegameContent> Create();
    }
}
