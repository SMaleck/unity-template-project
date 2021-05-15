using System;

namespace Source.Frameworks.Logging
{
    public interface ISavegameLogger
    {
        void Log(string message);
        void Error(string message);
        void Error(Exception e);
    }
}
