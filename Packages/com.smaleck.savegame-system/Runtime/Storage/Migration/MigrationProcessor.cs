namespace SavegameSystem.Storage.Migration
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
