using System.IO;
using UnityEngine;

namespace ExcelImporter.Editor
{
    public class Settings
    {
        private const string SettingsPath = "ProjectSettings/ExcelImporterSettings.json";
        
        [SerializeField] private string _importerNamespace;
        [SerializeField] private string _importerCodePath;

        [SerializeField] private string _sheetClassNamespace;
        [SerializeField] private string _sheetClassPath;
        
        [SerializeField] private string _scriptableObjectImportPath;
        [SerializeField] private string _ignoredSheetPrefix;
        [SerializeField] private string _ignoredColumnPrefix;

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
            _importerNamespace = "Game.Data";
            _importerCodePath = "Assets/Data/ExcelImports/Importers";

            _sheetClassNamespace = "Game.Data";
            _sheetClassPath = "Assets/Data/ExcelImports/Sheets";

            _scriptableObjectImportPath = "Assets/Data/ExcelImports/ImportedAssets";
            _ignoredSheetPrefix = "_";
            _ignoredColumnPrefix = "_";
        }
        
        public static string ClassNamespace
        {
            get => Instance._sheetClassNamespace;
            set
            {
                Instance._sheetClassNamespace = value;
                SetDirty(Instance._sheetClassNamespace != value);
            }
        }

        public static string ClassPath
        {
            get => Instance._sheetClassPath;
            set
            {
                Instance._sheetClassPath = value;
                SetDirty(Instance._sheetClassPath != value);
            }
        }

        public static string ExporterNamespace
        {
            get => Instance._importerNamespace;
            set
            {
                Instance._importerNamespace = value;
                SetDirty(Instance._importerNamespace != value);
            }
        }

        public static string ExporterPath
        {
            get => Instance._importerCodePath;
            set
            {
                Instance._importerCodePath = value;
                SetDirty(Instance._importerCodePath != value);
            }
        }

        public static string AssetPath
        {
            get => Instance._scriptableObjectImportPath;
            set
            {
                Instance._scriptableObjectImportPath = value;
                SetDirty(Instance._scriptableObjectImportPath != value);
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