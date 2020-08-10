using Source.Services.Savegames.Models;

namespace Source.Services.Savegames
{
    public interface ISavegameService
    {
        SavegameData Load();

        void EnqueueSaveRequest();
        void Save();
        
        void Reset();
    }
}
