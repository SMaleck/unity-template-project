using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExcelImporter.Editor.Processing;

namespace ExcelImporter.Editor.CodeGenerators
{
    internal static class ImporterCodeGenerator
    {
        public static void Generate(ExcelWorkbook workbook)
        {

        }

        public static void GenerateBookImporter(ExcelWorkbook workbook)
        {

        }

        public static void GenerateSheetImporter(ExcelSheet sheet)
        {

        }

        private static void Write(string templatePath, Dictionary<string, string> data)
        {
            var template = File.ReadAllText(templatePath);

        }
    }
}
