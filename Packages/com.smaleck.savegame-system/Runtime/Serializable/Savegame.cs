using System;

namespace SavegameSystem.Serializable
{
    [Serializable]
    public class Savegame<T> : ISavegame<T>
    {
        public SavegameMetaData MetaData { get; set; }
        public T Content { get; set; }
    }
}
