using Source.Frameworks.SavegameSystem.Models;

namespace Source.Frameworks.SavegameSystem.Storage
{
    public interface ISavegameReader
    {
        ISavegameData Read();
    }
}
