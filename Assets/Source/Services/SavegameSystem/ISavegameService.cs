﻿using Source.Frameworks.SavegameSystem.Serializable;
using Source.Services.SavegameSystem.Serialization;

namespace Source.Services.SavegameSystem
{
    public interface ISavegameService
    {
        ISavegame<SavegameContent> Load();
        void Save();
    }
}