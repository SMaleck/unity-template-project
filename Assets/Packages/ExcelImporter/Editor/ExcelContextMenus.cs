using System.Collections.Generic;
using ExcelImporter.Editor.Constants;
using ExcelImporter.Editor.Utility;
using UnityEditor;

namespace ExcelImporter.Editor
{
    public class ExcelContextMenus
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
