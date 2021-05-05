using ExcelImporter.Editor.ExcelProcessing;
using UnityEditor;

namespace ExcelImporter.Editor.CodeGenerators
{
    internal static class CodeGenerator
    {
        public const string WorkbookImporterSuffix = "WorkbookImporter";
        public const string SheetImportSuffix = "Import";

        private static readonly char[] TrimChars = { ' ', '-', '+', ':', ',', ';' };

        public static void Generate(ExcelWorkbook workbook)
        {
            WorkbookImporterCodeGenerator.Generate(workbook);

            foreach (var sheet in workbook.Sheets.Values)
            {
                SheetImportCodeGenerator.Generate(sheet);
            }

            AssetDatabase.Refresh();
        }

        public static string SanitizeClassName(string name)
        {
            return name.Trim(TrimChars);
        }

        public static string GetWorkbookClassName(string name)
        {
            var baseName = SanitizeClassName(name);
            return $"{baseName}{WorkbookImporterSuffix}";
        }

        public static string GetSheetClassName(string name)
        {
            var baseName = SanitizeClassName(name);
            return $"{baseName}{SheetImportSuffix}";
        }
    }
}
