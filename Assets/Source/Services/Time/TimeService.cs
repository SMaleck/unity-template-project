using System;

namespace Source.Services.Time
{
    public class TimeService : ITimeService
    {
        public DateTime Min => DateTime.MinValue;
        public virtual DateTime UtcNow => DateTime.UtcNow;
        public virtual DateTime ClientNow => DateTime.Now;
    }
}
