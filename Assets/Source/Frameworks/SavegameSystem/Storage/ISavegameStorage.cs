using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage
{
    public interface ISavegameStorage
    {
        bool TryLoad<T>(out ISavegame<T> savegame);
        bool TrySave<T>(ISavegame<T> savegame);
    }
}