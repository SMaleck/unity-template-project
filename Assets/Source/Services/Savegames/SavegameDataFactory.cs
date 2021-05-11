﻿using Source.Frameworks.SavegameSystem;
using Source.Frameworks.SavegameSystem.Models;
using Source.Services.Savegames.Models;

namespace Source.Services.Savegames
{
    public class SavegameFactory : ISavegameFactory
    {
        public ISavegameData Create()
        {
            return new SavegameData()
            {
            };
        }
    }
}
