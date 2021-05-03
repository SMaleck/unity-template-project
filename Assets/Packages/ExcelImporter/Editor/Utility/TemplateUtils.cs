using System.IO;
using System.Linq;
using UnityEditor;

namespace ExcelImporter.Editor.Utility
{
    public static class TemplateUtils
    {
        private static string _localPath;
        private static string LocalPath => string.IsNullOrEmpty(_localPath)
            ? (_localPath = GetLocalPath())
            : _localPath;

        private static char Sep => Path.DirectorySeparatorChar;
        private static readonly string Root = $"{LocalPath}{Sep}Templates{Sep}";

        public static string GeneratedCodeNoticeTemplate = $"{Root}GeneratedCodeNotice.cs.txt";
        public static string BookImporterTemplate = $"{Root}BookImporterTemplate.cs.txt";
        public static string SheetImporterTemplate = $"{Root}SheetImporterTemplate.cs.txt";

        private static string GetLocalPath()
        {
            var assetPath = AssetDatabase
                .FindAssets($"{nameof(Settings)} t:Script")
                .Select(AssetDatabase.GUIDToAssetPath)
                .First();

            return Path.GetDirectoryName(assetPath);
        }
    }
}
