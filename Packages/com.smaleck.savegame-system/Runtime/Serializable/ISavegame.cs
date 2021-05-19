namespace SavegameSystem.Serializable
{
    public interface ISavegame<T>
    {
        SavegameMetaData MetaData { get; }
        public T Content { get; set; }
    }
}
