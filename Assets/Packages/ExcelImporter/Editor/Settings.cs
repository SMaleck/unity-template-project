using System.IO;
using UnityEngine;

namespace ExcelImporter.Editor
{
    public class Settings
    {
        private const string SettingsPath = "ProjectSettings/ExcelImporterSettings.json";
        
        [SerializeField] private string _importerNamespace;
        [SerializeField] private string _importerCodePath;

        [SerializeField] private string _sheetNamespace;
        [SerializeField] private string _sheetCodePath;
        
        [SerializeField] private string _importAssetPath;
        [SerializeField] private string _ignoredSheetPrefix;
        [SerializeField] private string _ignoredColumnPrefix;
        [SerializeField] private string _menuPath;

        private static Settings _instance;
        private static Settings Instance
        {
            get
            {
                if (_instance == null)
                {
                    if (!TryLoad(out _instance))
                    {
                        _instance = new Settings();
                        Save();
                    }
                }

                return _instance;
            }
        }

        public Settings()
        {
            _importerNamespace = "Game.Data.Imports";
            _importerCodePath = "Assets/Data/Generated/Importers";

            _sheetNamespace = "Game.Data.Imports";
            _sheetCodePath = "Assets/Data/Generated/Sheets";

            _importAssetPath = "Assets/Data/Imports/";
            _ignoredSheetPrefix = "_";
            _ignoredColumnPrefix = "_";
        }

        public static string SheetNamespace
        {
            get => Instance._sheetNamespace;
            set
            {
                Instance._sheetNamespace = value;
                SetDirty(Instance._sheetNamespace != value);
            }
        }

        public static string SheetCodePath
        {
            get => Instance._sheetCodePath;
            set
            {
                Instance._sheetCodePath = value;
                SetDirty(Instance._sheetCodePath != value);
            }
        }

        public static string ImporterNamespace
        {
            get => Instance._importerNamespace;
            set
            {
                Instance._importerNamespace = value;
                SetDirty(Instance._importerNamespace != value);
            }
        }

        public static string ImporterCodePath
        {
            get => Instance._importerCodePath;
            set
            {
                Instance._importerCodePath = value;
                SetDirty(Instance._importerCodePath != value);
            }
        }

        public static string ImportAssetPath
        {
            get => Instance._importAssetPath;
            set
            {
                Instance._importAssetPath = value;
                SetDirty(Instance._importAssetPath != value);
            }
        }

        public static string IgnoredSheetPrefix
        {
            get => Instance._ignoredSheetPrefix;
            set
            {
                Instance._ignoredSheetPrefix = value;
                SetDirty(Instance._ignoredSheetPrefix != value);
            }
        }
        
        public static string IgnoredColumnPrefix
        {
            get => Instance._ignoredColumnPrefix;
            set
            {
                Instance._ignoredColumnPrefix = value;
                SetDirty(Instance._ignoredColumnPrefix != value);
            }
        }

        private static bool TryLoad(out Settings settings)
        {
            if (!File.Exists(SettingsPath))
            {
                settings = null;
                return false;
            }

            var fileContent = File.ReadAllText(SettingsPath);
            settings = JsonUtility.FromJson<Settings>(fileContent);

            return true;
        }

        private static void Save()
        {
            var json = JsonUtility.ToJson(Instance);
            File.WriteAllText(SettingsPath, json);
        }

        private static void SetDirty(bool isDirty)
        {
            if (isDirty)
            {
                Save();
            }
        }
    }
}