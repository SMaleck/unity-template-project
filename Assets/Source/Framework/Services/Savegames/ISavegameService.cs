using Source.Framework.Services.Savegames.Models;

namespace Source.Framework.Services.Savegames
{
    public interface ISavegameService
    {
        Savegame Savegame { get; }
        void Reset();
    }
}
