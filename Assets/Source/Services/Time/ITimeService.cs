﻿using System;
using Source.Frameworks.SavegameSystem.Storage;

namespace Source.Services.Time
{
    public interface ITimeService : ISavegameTimeProvider
    {
        DateTime Min { get; }
        DateTime UtcNow { get; }
        DateTime ClientNow { get; }
    }
}