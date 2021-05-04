using ExcelImporter.Editor.CodeTemplates;
using ExcelImporter.Editor.Constants;
using ExcelImporter.Editor.ExcelProcessing;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExcelImporter.Editor.CodeGenerators
{
    // ToDo XLS PREFIX_ASSETNAME
    // ToDo XLS Progress in import statements
    public class WorkbookImporterCodeGenerator
    {
        private static readonly char[] TrimChars = { ' ', '-', '+', ':', ',', ';' };

        public static void Generate(ExcelWorkbook workbook)
        {
            var data = new Dictionary<string, string>();

            var className = GetSanitizedClassName(workbook.Name);

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

        // ToDo XLS Move to central place
        private static string GetSanitizedClassName(string name)
        {
            var baseName = name.Trim(TrimChars);
            return $"{baseName}Import";
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

            foreach (var sheet in workbook.Sheets.Values)
            {
                var sheetClassName = GetSanitizedClassName(sheet.Name);
                var statement = template.Replace(TemplateKeys.SHEET_NAME, sheetClassName);

                sb.AppendLine(statement);
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
