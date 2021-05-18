namespace SavegameSystem.Storage.Processors
{
    public interface IMigrationProcessor
    {
        string Process(string savegameJson);
    }
}