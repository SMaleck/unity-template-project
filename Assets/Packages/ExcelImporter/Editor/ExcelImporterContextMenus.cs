using ExcelImporter.Editor.Constants;
using ExcelImporter.Editor.Utility;
using UnityEditor;

namespace ExcelImporter.Editor
{
    public class ExcelImporterContextMenus
    {
        [MenuItem(MenuConstants.ContextRoot + "/Generate Importers")]
        public static void GenerateImporters()
        {
            if (!ImportUtils.TryFindExcelPathsInSelection(out var excelPaths))
            {
                EditorUtils.ErrorNoExcelSelected();
            }

            ExcelProcessor.Process(excelPaths);
        }
    }
}
