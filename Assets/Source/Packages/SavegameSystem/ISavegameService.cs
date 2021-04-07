using Source.Packages.SavegameSystem.Models;

namespace Source.Packages.SavegameSystem
{
    public interface ISavegameService
    {
        ISavegameData Load();

        void EnqueueSaveRequest();
        void Save();

        void Reset();
    }
}
