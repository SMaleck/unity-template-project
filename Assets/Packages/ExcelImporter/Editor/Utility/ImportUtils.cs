using ExcelImporter.Editor.Constants;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;

namespace ExcelImporter.Editor.Utility
{
    internal class ImportUtils
    {
        public const string ExcelFileExtension = ".xlsx";

        public static bool TryFindExcelPathsInSelection(out string[] excelPaths)
        {
            var paths = Selection.objects
                .Select(AssetDatabase.GetAssetPath);

            return TryFindExcelFiles(paths, out excelPaths);
        }

        public static bool TryFindExcelFiles(IEnumerable<string> filePaths, out string[] excelPaths)
        {
            excelPaths = Selection.objects.Select(AssetDatabase.GetAssetPath)
                .Where(IsExcelFile)
                .ToArray();

            return filePaths.Any();
        }

        public static bool IsExcelFile(string path)
        {
            return Path.GetExtension(path) == ExcelFileExtension;
        }
    }
}
