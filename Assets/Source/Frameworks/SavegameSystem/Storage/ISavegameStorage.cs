using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage
{
    public interface ISavegameStorage
    {
        bool TryLoad(out ISavegame savegame);
        bool TrySave(ISavegame savegame);
    }
}