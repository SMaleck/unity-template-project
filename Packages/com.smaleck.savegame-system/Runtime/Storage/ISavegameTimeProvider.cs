using System;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage
{
    public interface ISavegameTimeProvider
    {
        DateTime UtcNow { get; }
    }
}
