using Source.Frameworks;
using Source.ServicesStatic.LocalPlayerPrefs;
using UnityEditor;

namespace Assets.Editor.Persistence
{
    public static class PlayerPrefsTool
    {
        [MenuItem(Constants.MenuRoot + "PlayerPrefs - Log")]
        public static void LogPlayerPrefs()
        {
            PlayerPrefsService.LogAll();
        }
    }
}
