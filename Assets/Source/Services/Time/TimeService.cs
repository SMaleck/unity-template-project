using System;
using SavegameSystem.Storage;
using SavegameSystem.Storage.ResourceProviders;

namespace Source.Services.Time
{
    public class TimeService : ITimeService, ISavegameTimeProvider
    {
        public DateTime Min => DateTime.MinValue;
        public virtual DateTime UtcNow => DateTime.UtcNow;
        public virtual DateTime ClientNow => DateTime.Now;
    }
}
