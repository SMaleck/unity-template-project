using System.Collections.Generic;
using System.IO;
using System.Linq;
using NPOI.SS.UserModel;

namespace ExcelImporter.Editor.Processing
{
    public class ExcelWorkbook
    {
        public string FilePath { get; }
        public string Name { get; }
        public Dictionary<string, ExcelSheet> Sheets { get; }

        public ExcelWorkbook(string filePath, IWorkbook workbook)
        {
            FilePath = filePath;
            Name = Path.GetFileNameWithoutExtension(filePath);
            Sheets = GetSheets(workbook);
        }

        private Dictionary<string, ExcelSheet> GetSheets(IWorkbook workbook)
        {
            var sheets = new List<ExcelSheet>();

            for (var i = 0; i < workbook.NumberOfSheets; i++)
            {
                var sheet = workbook.GetSheetAt(i);

                if (IsIgnoredSheet(sheet.SheetName))
                {
                    continue;
                }
                
                sheets.Add(new ExcelSheet(sheet));
            }

            return sheets.ToDictionary(e => e.Name);
        }

        private bool IsIgnoredSheet(string sheetName)
        {
            return sheetName.StartsWith(Settings.IgnoredSheetPrefix);
        }
    }
}
