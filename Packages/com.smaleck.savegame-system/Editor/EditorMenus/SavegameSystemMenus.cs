using SavegameSystem.Editor.Constants;
using SavegameSystem.Settings;
using System.IO;
using UnityEditor;

namespace SavegameSystem.Editor.EditorMenus
{
    public static class SavegameSystemMenus
    {
        [MenuItem(MenuConstants.MenuRoot + "/Open Settings", priority = MenuConstants.Priority1)]
        public static void OpenSettings()
        {
            if (!File.Exists(SavegameSettings.SettingsPath))
            {
                CreateSettings();
            }

            Selection.activeObject = AssetDatabase.LoadMainAssetAtPath(SavegameSettings.SettingsPath);
        }

        [MenuItem(MenuConstants.MenuRoot + "/Create Settings", priority = MenuConstants.Priority1)]
        public static void CreateSettings()
        {
            ResetSettings();
        }

        [MenuItem(MenuConstants.MenuRoot + "/Reset Settings", priority = MenuConstants.Priority1)]
        public static void ResetSettings()
        {
            EditorUtils.LoadOrCreateAsset<SavegameSettings>(
                SavegameSettings.SettingsPath,
                out var settings);

            settings.Reset();
        }
    }
}
