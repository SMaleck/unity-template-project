namespace SavegameSystem.Storage.Dal
{
    public interface ISavegameWriter
    {
        void Write(string serializedSavegame);
    }
}
