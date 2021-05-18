namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Processors
{
    public class MigrationProcessor : IMigrationProcessor
    {
        public MigrationProcessor()
        {
        }

        public string Process(string savegameJson)
        {
            return savegameJson;
        }
    }
}
