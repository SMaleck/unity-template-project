namespace Source.Frameworks.SavegameSystem.Storage.Processors
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
