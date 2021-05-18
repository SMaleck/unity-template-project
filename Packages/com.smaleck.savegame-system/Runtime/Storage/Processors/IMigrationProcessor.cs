namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Processors
{
    public interface IMigrationProcessor
    {
        string Process(string savegameJson);
    }
}