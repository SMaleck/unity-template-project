using System;

namespace Source.Frameworks.SavegameSystem.Serializable
{
    public class Savegame<T> : ISavegame<T>
    {
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public int Version { get; set; }

        public T Content { get; set; }
    }
}
