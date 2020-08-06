using Source.Services.Savegames.Models;

namespace Source.Services.Savegames.Storage
{
    public interface ISavegameWriter
    {
        void Write(SavegameData savegameData);
    }
}
