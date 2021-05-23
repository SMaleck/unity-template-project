namespace SavegameSystem.Storage.Migration
{
    public interface ISavegameMigration
    {
        int Version { get; }
        string Migrate(string savegameJson);
    }
}