using System;

namespace Source.Frameworks.SavegameSystem.Runtime.Logging
{
    public interface ISavegameLogger
    {
        void Log(string message);
        void Error(string message);
        void Error(Exception e);
    }
}
