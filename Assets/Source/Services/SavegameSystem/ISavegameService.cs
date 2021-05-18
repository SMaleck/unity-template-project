using SavegameSystem.Serializable;
using Source.Services.SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem
{
    public interface ISavegameService
    {
        ISavegame<SavegameContent> Load();
        void Save();
    }
}