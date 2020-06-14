using UnityEngine;

namespace Source.Framework.Services.LocalPlayerPrefs
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
    }
}
