namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Dal
{
    public interface ISavegameWriter
    {
        void Write(string serializedSavegame);
    }
}
