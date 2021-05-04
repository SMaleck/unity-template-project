using ExcelImporter.Editor.CodeTemplates;
using ExcelImporter.Editor.ExcelProcessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ExcelImporter.Editor.CodeGenerators
{
    public static class SheetImportCodeGenerator
    {
        private static readonly char[] TrimChars = { ' ', '-', '+', ':', ',', ';' };

        public static void Generate(ExcelSheet sheet)
        {
            var data = new Dictionary<string, string>();

            var className = GetSanitizedClassName(sheet.Name);

            data.Add(TemplateKeys.NAMESPACE, Settings.ClassNamespace);
            data.Add(TemplateKeys.CLASS_NAME, className);
            data.Add(TemplateKeys.FIELDS, GenerateFields(sheet));

            Templates.Write(
                Templates.SheetImportTemplate,
                GetFilePath(className),
                data);
        }

        private static string GetSanitizedClassName(string name)
        {
            var baseName = name.Trim(TrimChars);
            return $"{baseName}Import";
        }

        private static string GetFilePath(string name)
        {
            return Path.Combine(Settings.ClassPath, $"{name}.cs");
        }

        private static string GenerateFields(ExcelSheet sheet)
        {
            var sb = new StringBuilder();

            foreach (var col in sheet.Columns)
            {
                var type = GetTypeString(col.Type);
                sb.AppendLine($"            public {type} {col.Name};");
            }

            return sb.ToString();
        }

        private static string GetTypeString(ColumnValueType valueType)
        {
            switch (valueType)
            {
                case ColumnValueType.Bool:
                    return "bool";

                case ColumnValueType.String:
                    return "string";

                case ColumnValueType.Int:
                    return "int";

                case ColumnValueType.Long:
                    return "long";

                case ColumnValueType.Float:
                    return "float";

                case ColumnValueType.Double:
                    return "double";

                default:
                    throw new ArgumentOutOfRangeException(nameof(valueType), valueType, null);
            }
        }
    }
}
