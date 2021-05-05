using ExcelImporter.Editor.Constants;
using ExcelImporter.Editor.EditorWindows;
using ExcelImporter.Editor.Utility;
using UnityEditor;

namespace ExcelImporter.Editor.EditorMenus
{
    public class ExcelImporterContextMenus
    {
        [MenuItem(MenuConstants.ContextRoot + "/Generate Importers")]
        public static void GenerateImporters()
        {
            if (!ImportUtils.TryFilterExcelPathsInSelection(out var filePaths))
            {
                EditorUtils.ErrorNoExcelSelected();
                return;
            }

            foreach (var filePath in filePaths)
            {
                GenerateImporterWindow.OpenFor(filePath);
            }
        }

        [MenuItem(MenuConstants.ContextRoot + "/Generate Importers with shared settings")]
        public static void GenerateImportersBatch()
        {
            if (!ImportUtils.TryFilterExcelPathsInSelection(out var filePaths))
            {
                EditorUtils.ErrorNoExcelSelected();
                return;
            }

            GenerateImporterBatchWindow.OpenFor(filePaths);
        }

        [MenuItem(MenuConstants.ContextRoot + "/Import Selected")]
        public static void ImportSelected()
        {
            if (!ImportUtils.TryFilterExcelPathsInSelection(out var filePaths))
            {
                EditorUtils.ErrorNoExcelSelected();
                return;
            }

            GenerateImporterBatchWindow.OpenFor(filePaths);
        }
    }
}
