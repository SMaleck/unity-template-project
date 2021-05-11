using Source.Frameworks.SavegameSystem.Models;

namespace Source.Frameworks.SavegameSystem
{
    public interface ISavegameService
    {
        ISavegameData Load();

        void EnqueueSaveRequest();
        void Save();

        void Reset();
    }
}
