using SavegameSystem.Serializable;

namespace SavegameSystem.Storage
{
    public interface ISavegameStorage
    {
        bool TryLoad<T>(out ISavegame<T> savegame);
        bool TrySave<T>(ISavegame<T> savegame);
    }
}