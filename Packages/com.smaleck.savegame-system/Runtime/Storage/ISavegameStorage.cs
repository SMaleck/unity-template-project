using SavegameSystem.Serializable;

namespace SavegameSystem.Storage
{
    public interface ISavegameStorage
    {
        bool TryLoad<T>(out ISavegame<T> savegame) where T : class;
        bool TrySave<T>(ISavegame<T> savegame) where T : class;
    }
}