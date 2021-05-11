using Source.Frameworks.SavegameSystem.Models;

namespace Source.Frameworks.SavegameSystem.Storage
{
    public interface ISavegameWriter
    {
        void Write(ISavegameData savegameData);
    }
}
