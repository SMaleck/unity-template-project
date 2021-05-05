using ExcelImporter.Editor.ExcelProcessing;
using ExcelImporter.Editor.Utility;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ExcelImporter.Editor.Importers
{
    public class SheetImporter
    {
        private const int StartRow = 3;

        public static void ImportData<TSheet, TRow>(ExcelWorkbook workbook, string sheetName, string importFilePath)
            where TSheet : ScriptableObject
            where TRow : new()
        {
            try
            {
                AssertWorkbookIsValid(workbook, sheetName, importFilePath);

                var excelSheet = workbook.Sheets[sheetName];
                var asset = CreateAsset<TSheet>(importFilePath);

                var importedRows = new List<TRow>();

                var colCount = excelSheet.Columns.Length;
                var rowCount = excelSheet.Sheet.LastRowNum;

                for (var row = StartRow; row <= rowCount; row++)
                {
                    var importRow = new TRow();
                    for (var col = 0; col < colCount; col++)
                    {
                        PopulateCellValue(excelSheet, col, row, importRow);
                    }

                    importedRows.Add(importRow);
                }

                // Set imported row data on the asset using reflection, so we don't need to have
                // a base class ensuring "Rows" is accessible at compile time
                typeof(TSheet)
                    .GetField("Rows")
                    .SetValue(asset, importedRows);

                EditorUtility.SetDirty(asset);
                AssetDatabase.SaveAssets();

                UnityEngine.Debug.Log($"Imported {importedRows.Count} rows from {sheetName}");
            }
            catch (Exception e)
            {
                EditorUtils.Error(e, $"Failed to Import {sheetName} from {workbook?.FilePath}");
            }
        }

        private static void AssertWorkbookIsValid(ExcelWorkbook workbook, string sheetName, string importFilePath)
        {
            if (workbook == null)
            {
                throw new ArgumentException($"{nameof(workbook)} cannot be NULL");
            }
            if (string.IsNullOrWhiteSpace(sheetName))
            {
                throw new ArgumentException($"{nameof(sheetName)} cannot be NULL or EMPTY");
            }
            if (string.IsNullOrWhiteSpace(importFilePath))
            {
                throw new ArgumentException($"{nameof(importFilePath)} cannot be NULL or EMPTY");
            }
            if (!workbook.Sheets.ContainsKey(sheetName))
            {
                throw new ArgumentException($"Workbook does not contain sheet {sheetName}");
            }
        }

        private static TAsset CreateAsset<TAsset>(string filePath) where TAsset : ScriptableObject
        {
            if (!EditorUtils.LoadOrCreateAsset<TAsset>(filePath, out var asset))
            {
                asset.hideFlags = HideFlags.HideInInspector;
            }

            return asset;
        }

        private static void PopulateCellValue<TRow>(ExcelSheet sheet, int col, int row, TRow target)
        {
            var fieldName = sheet.Columns[col].Name;
            var fieldType = sheet.Columns[col].Type;

            object cellValue = null;

            try
            {
                var sheetRow = sheet.Sheet.GetRow(row);
                var cell = sheetRow.GetCell(col);

                cellValue = GetCellValue(cell, fieldType);
            }
            catch (Exception e)
            {
                throw new InvalidOperationException($"Cell Failed! SHEET: {sheet.Name} NAME: {fieldName} TYPE: {fieldType} COL: {col} ROW: {row} | ({e.Message})");
            }

            typeof(TRow)
                .GetField(fieldName)
                .SetValue(target, cellValue);
        }

        private static object GetCellValue(ICell cell, ColumnValueType cellType)
        {
            object cellValue = null;

            if (cell == null || cell.CellType == CellType.Blank)
            {
                throw new ArgumentException("Cell cannot be NULL or EMPTY");
            }

            switch (cellType)
            {
                case ColumnValueType.Bool:
                    cellValue = cell.BooleanCellValue;
                    break;

                case ColumnValueType.String:
                    cellValue = cell.StringCellValue;
                    break;

                case ColumnValueType.Int:
                    cellValue = (int)cell.NumericCellValue;
                    break;

                case ColumnValueType.Long:
                    cellValue = (long)cell.NumericCellValue;
                    break;

                case ColumnValueType.Float:
                    cellValue = (float)cell.NumericCellValue;
                    break;

                case ColumnValueType.Double:
                    cellValue = (double)cell.NumericCellValue;
                    break;

                default:
                    throw new ArgumentOutOfRangeException($"No operation defined for field type {cellType}");
            }

            if (cellValue == null)
            {
                throw new ArgumentException("Field cannot be NULL");
            }

            return cellValue;
        }
    }
}
