﻿using ExcelImporter.Editor.Utility;

namespace ExcelImporter.Editor
{
    public static class Settings
    {
        public static string SettingsPath = PathUtils.LocalPath + "/ExcelImporterSettings.asset";

        private static SettingsScriptableObject _instance;
        private static SettingsScriptableObject Instance => _instance ?? (_instance = LoadSettings());

        public static string SheetNamespace => Instance.SheetNamespace;
        public static string SheetCodePath => Instance.SheetCodePath;
        public static string ImporterNamespace => Instance.ImporterNamespace;
        public static string ImporterCodePath => Instance.ImporterCodePath;
        public static string ImportAssetPath => Instance.ImportAssetPath;
        public static string IgnoredSheetPrefix => Instance.IgnoredSheetPrefix;
        public static string IgnoredColumnPrefix => Instance.IgnoredColumnPrefix;

        private static SettingsScriptableObject LoadSettings()
        {
            if (!EditorUtils.LoadOrCreateAsset<SettingsScriptableObject>(SettingsPath, out var asset))
            {
                asset.ResetDefaults();
            }

            return asset;
        }

        public static void Reset()
        {
            Reload();
            _instance.ResetDefaults();
        }

        public static void Reload()
        {
            var settings = LoadSettings();
            _instance = settings;
        }
    }
}