using System;

namespace Source.Services.Time
{
    public interface ITimeService
    {
        DateTime Min { get; }
        DateTime UtcNow { get; }
        DateTime ClientNow { get; }
    }
}