using ExcelImporter.Editor.Processing;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace ExcelImporter.Editor.Templates.CompilingTemplates
{
    public class SheetImporter
    {
        private const int StartRow = 2;

        public static void ImportData<TSheet, TRow>(ExcelWorkbook workbook, string sheetName, string importFilePath) 
            where TSheet : AbstractSheetImport<TRow>
            where TRow : new()
        {
            var excelSheet = workbook.Sheets[sheetName];
            var asset = CreateAsset<TSheet>(importFilePath);

            var importedRows = new List<TRow>();

            var colCount = excelSheet.Columns.Length;
            var rowCount = excelSheet.Sheet.LastRowNum;

            try
            {
                for (var row = StartRow; row <= rowCount; row++)
                {
                    var importRow = new TRow();
                    for (var col = 0; col < colCount; col++)
                    {
                        PopulateCellValue(excelSheet, col, row, importRow);
                    }

                    importedRows.Add(importRow);
                }
            }
            catch (Exception e)
            {
                UnityEngine.Debug.LogError($"Failed to Import {sheetName} from {workbook.FilePath}");
                UnityEngine.Debug.LogError(e);
            }

            asset.Rows = importedRows;

            EditorUtility.SetDirty(asset);
            AssetDatabase.SaveAssets();

            UnityEngine.Debug.Log($"Imported {importedRows.Count} rows from {sheetName}");
        }

        private static TAsset CreateAsset<TAsset>(string filePath) where TAsset : ScriptableObject
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            if (!TryLoadAsset<TAsset>(filePath, out var asset))
            {
                asset = ScriptableObject.CreateInstance<TAsset>();
                asset.hideFlags = HideFlags.HideInInspector;

                AssetDatabase.CreateAsset((ScriptableObject)asset, filePath);
            }

            return asset;
        }

        private static bool TryLoadAsset<TAsset>(string filePath, out TAsset asset) where TAsset : ScriptableObject
        {
            asset = (TAsset)AssetDatabase.LoadAssetAtPath(filePath, typeof(TAsset));
            return asset != null;
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
