using System;

namespace SavegameSystem.Storage
{
    public interface ISavegameTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
