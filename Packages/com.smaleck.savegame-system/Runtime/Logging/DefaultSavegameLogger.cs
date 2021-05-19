namespace SavegameSystem.Logging
{
    public class DefaultSavegameLogger : ISavegameLogger
    {
        private const string Prefix = "[Savegame]";

        public void Log(object payload)
        {
            if (UnityEngine.Debug.isDebugBuild)
            {
                UnityEngine.Debug.Log($"{Prefix} {ToMessage(payload)}");
            }
        }

        public void Warn(object payload)
        {
            if (UnityEngine.Debug.isDebugBuild)
            {
                UnityEngine.Debug.LogWarning($"{Prefix} {ToMessage(payload)}");
            }
        }

        public void Error(object payload)
        {
            if (UnityEngine.Debug.isDebugBuild)
            {
                UnityEngine.Debug.LogError($"{Prefix} {ToMessage(payload)}");
            }
        }

        private string ToMessage(object payload)
        {
            return payload?.ToString() ?? string.Empty;
        }
    }
}
