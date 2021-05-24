using SavegameSystem.Serializable;

namespace SavegameSystem.Storage
{
    public class SavegameStorageResult<T> where T: class
    {
        public bool Success { get; }
        public ISavegame<T> Savegame { get; }
    }
}
