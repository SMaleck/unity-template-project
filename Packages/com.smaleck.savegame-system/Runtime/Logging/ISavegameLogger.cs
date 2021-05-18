using System;

namespace SavegameSystem.Logging
{
    public interface ISavegameLogger
    {
        void Log(string message);
        void Error(string message);
        void Error(Exception e);
    }
}
