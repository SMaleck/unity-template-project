using Source.Packages.SavegameSystem.Models;

namespace Source.Packages.SavegameSystem.Storage
{
    public interface ISavegameWriter
    {
        void Write(ISavegameData savegameData);
    }
}
