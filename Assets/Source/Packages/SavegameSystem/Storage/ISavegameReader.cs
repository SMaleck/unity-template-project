using Source.Packages.SavegameSystem.Models;

namespace Source.Packages.SavegameSystem.Storage
{
    public interface ISavegameReader
    {
        ISavegameData Read();
    }
}
