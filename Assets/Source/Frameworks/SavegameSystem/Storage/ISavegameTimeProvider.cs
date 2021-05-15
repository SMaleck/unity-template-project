using System;

namespace Source.Frameworks.SavegameSystem.Storage
{
    public interface ISavegameTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
