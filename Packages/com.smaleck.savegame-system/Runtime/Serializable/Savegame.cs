using System;

namespace SavegameSystem.Serializable
{
    [Serializable]
    public class Savegame<T> : ISavegame<T>
    {
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public int Version { get; set; }

        public SavegameMetaData MetaData { get; set; }

        public T Content { get; set; }
    }
}
