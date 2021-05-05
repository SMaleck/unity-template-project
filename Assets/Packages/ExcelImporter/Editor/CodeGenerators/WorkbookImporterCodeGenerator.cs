using ExcelImporter.Editor.CodeTemplates;
using ExcelImporter.Editor.Constants;
using ExcelImporter.Editor.ExcelProcessing;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace ExcelImporter.Editor.CodeGenerators
{
    // ToDo XLS PREFIX_ASSETNAME
    public class WorkbookImporterCodeGenerator
    {
        public static void Generate(ExcelWorkbook workbook)
        {
            var data = new Dictionary<string, string>();

            var className = CodeGenerator.GetWorkbookClassName(workbook.Name);

            data.Add(TemplateKeys.NAMESPACE, Settings.ImporterNamespace);
            data.Add(TemplateKeys.CLASS_NAME, className);
            data.Add(TemplateKeys.MENU_PATH, GetMenuPath(className));
            data.Add(TemplateKeys.EXCEL_FILEPATH, workbook.FilePath);
            data.Add(TemplateKeys.IMPORT_BASEPATH, Settings.ImportAssetPath);
            data.Add(TemplateKeys.PREFIX_ASSETNAME, "true");
            data.Add(TemplateKeys.SHEET_IMPORT_STATEMENTS, GenerateImportStatements(workbook));

            Templates.Write(
                Templates.WorkbookImporterTemplate,
                GetFilePath(className),
                data);
        }

        private static string GetMenuPath(string name)
        {
            return $"{MenuConstants.ImporterBase} {name}";
        }

        private static string GetFilePath(string name)
        {
            return Path.Combine(Settings.ImporterCodePath, $"{name}.cs");
        }

        private static string GenerateImportStatements(ExcelWorkbook workbook)
        {
            var template = Templates.Read(Templates.ImportStatementTemplate);
            var sb = new StringBuilder();

            var currentProgress = 0f;
            var progressChunk = 1.0f / workbook.Sheets.Count;

            foreach (var sheet in workbook.Sheets.Values)
            {
                currentProgress += progressChunk;

                var sheetClassName = CodeGenerator.GetSheetClassName(sheet.Name);

                var statement = template
                    .Replace(TemplateKeys.SHEET_NAME, sheetClassName)
                    .Replace(TemplateKeys.PROGRESS, currentProgress.ToString(CultureInfo.InvariantCulture));

                sb.AppendLine(statement);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
