namespace Source.Framework.Services.Savegames
{
    public interface ISavegamePersistenceService
    {
        void EnqueueSaveRequest();
        void Save();
        void Load();
    }
}
