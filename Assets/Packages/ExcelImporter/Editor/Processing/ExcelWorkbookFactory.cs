using ExcelImporter.Editor.Utility;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;

namespace ExcelImporter.Editor.Processing
{
    public static class ExcelWorkbookFactory
    {
        public static ExcelWorkbook Create(string filePath)
        {
            var loadedWorkBook = LoadWorkbook(filePath);
            return new ExcelWorkbook(filePath, loadedWorkBook);
        }

        private static IWorkbook LoadWorkbook(string path)
        {
            if (!ImportUtils.IsExcelFile(path))
            {
                throw new ArgumentException($"Not an Excel file: {path}");
            }

            IWorkbook workbook;

            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                workbook = new XSSFWorkbook(stream);
            }

            return workbook;
        }
    }
}
