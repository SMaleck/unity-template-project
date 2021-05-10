using Newtonsoft.Json;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UtilitiesGeneral.Logging;

namespace Source.ServicesStatic.LocalPlayerPrefs
{
    public static class PlayerPrefsKeys
    {
        public const string PREFS_KEY_LANGUAGE = "Game.Language";
    }

    public static class PlayerPrefsService
    {
        public static int Language
        {
            get => PlayerPrefs.GetInt(PlayerPrefsKeys.PREFS_KEY_LANGUAGE);
            set => PlayerPrefs.SetInt(PlayerPrefsKeys.PREFS_KEY_LANGUAGE, value);
        }

        public static void Clear()
        {
            PlayerPrefs.DeleteAll();
        }

        public static void LogAll()
        {
            var allPrefs = typeof(PlayerPrefsKeys).GetFields(BindingFlags.Static | BindingFlags.Public)
                .Select(field => field.GetValue(null) as string)
                .Where(PlayerPrefs.HasKey)
                .ToDictionary(key => key, FindValueByKey);

            var playerPrefsJson = JsonConvert.SerializeObject(allPrefs, Formatting.Indented);

            StaticLogger.Log($"Player Prefs:\n{playerPrefsJson}");
        }

        private static object FindValueByKey(string key)
        {
            if (!PlayerPrefs.HasKey(key))
            {
                return null;
            }

            var stringValue = PlayerPrefs.GetString(key);
            if (!string.IsNullOrEmpty(stringValue))
            {
                return stringValue;
            }

            var floatValue = PlayerPrefs.GetFloat(key, float.NaN);
            if (!float.IsNaN(floatValue))
            {
                return floatValue;
            }

            return PlayerPrefs.GetInt(key);
        }
    }
}
