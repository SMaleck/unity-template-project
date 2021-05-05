using UnityEngine;

namespace ExcelImporter.Editor
{
    [CreateAssetMenu]
    public class SettingsScriptableObject : ScriptableObject
    {
        [SerializeField] private string _importerNamespace;
        [SerializeField] private string _importerCodePath;

        [SerializeField] private string _sheetNamespace;
        [SerializeField] private string _sheetCodePath;

        [SerializeField] private string _importAssetPath;
        [SerializeField] private string _ignoredSheetPrefix;
        [SerializeField] private string _ignoredColumnPrefix;

        public string SheetNamespace => _sheetNamespace;
        public string SheetCodePath => _sheetCodePath;
        public string ImporterNamespace => _importerNamespace;
        public string ImporterCodePath => _importerCodePath;
        public string ImportAssetPath => _importAssetPath;
        public string IgnoredSheetPrefix => _ignoredSheetPrefix;
        public string IgnoredColumnPrefix => _ignoredColumnPrefix;

        public void ResetDefaults()
        {
            _importerNamespace = "Game.Data.Imports";
            _importerCodePath = "Assets/Data/Generated/Importers";

            _sheetNamespace = "Game.Data.Imports";
            _sheetCodePath = "Assets/Data/Generated/Sheets";

            _importAssetPath = "Assets/Data/Imports/";
            _ignoredSheetPrefix = "_";
            _ignoredColumnPrefix = "_";
        }
    }
}