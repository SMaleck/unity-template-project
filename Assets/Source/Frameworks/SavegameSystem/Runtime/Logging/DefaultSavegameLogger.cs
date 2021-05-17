using System;

namespace Source.Frameworks.SavegameSystem.Runtime.Logging
{
    public class DefaultSavegameLogger : ISavegameLogger
    {
        private const string Prefix = "[Savegame]";

        public void Log(string message)
        {
            UnityEngine.Debug.Log($"{Prefix} {message}");
        }

        public void Error(string message)
        {
            UnityEngine.Debug.LogError($"{Prefix} {message}");
        }

        public void Error(Exception e)
        {
            UnityEngine.Debug.LogError(e);
        }
    }
}
