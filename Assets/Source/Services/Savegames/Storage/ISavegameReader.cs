using Source.Services.Savegames.Models;

namespace Source.Services.Savegames.Storage
{
    public interface ISavegameReader
    {
        SavegameData Read();
    }
}
