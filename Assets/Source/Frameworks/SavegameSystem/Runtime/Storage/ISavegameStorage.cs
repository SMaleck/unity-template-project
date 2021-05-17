using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage
{
    public interface ISavegameStorage
    {
        bool TryLoad<T>(out ISavegame<T> savegame);
        bool TrySave<T>(ISavegame<T> savegame);
    }
}