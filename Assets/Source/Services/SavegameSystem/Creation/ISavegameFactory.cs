﻿using SavegameSystem.Serializable;
using Source.Services.SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem.Creation
{
    public interface ISavegameFactory
    {
        ISavegame<SavegameContent> Create();
    }
}
