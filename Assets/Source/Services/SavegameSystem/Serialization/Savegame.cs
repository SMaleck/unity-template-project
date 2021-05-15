using System;
using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem.Serialization
{
    [Serializable]
    public class Savegame : ISavegame<SavegameContent>
    {
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
        public int Version { get; set; }
        public SavegameContent Content { get; set; }
    }
}
