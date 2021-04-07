using Source.Packages.SavegameSystem.Models;

namespace Source.Packages.SavegameSystem
{
    public interface ISavegameFactory
    {
        ISavegameData Create();
    }
}
