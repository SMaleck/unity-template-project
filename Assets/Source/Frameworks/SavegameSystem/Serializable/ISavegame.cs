using System;

namespace Source.Frameworks.SavegameSystem.Serializable
{
    public interface ISavegame<T>
    {
        public DateTime CreatedAtUtc { get; }
        public DateTime UpdatedAtUtc { get; set; }
        public int Version { get; set; }

        public T Content { get; set; }
    }

    public interface ISavegame : ISavegame<object>
    {
    }
}
