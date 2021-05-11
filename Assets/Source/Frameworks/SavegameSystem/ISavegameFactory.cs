using Source.Frameworks.SavegameSystem.Models;

namespace Source.Frameworks.SavegameSystem
{
    public interface ISavegameFactory
    {
        ISavegameData Create();
    }
}
