﻿/* -------------------------------------------------------
 * WARNING:
 *
 * This code was generated by the Excel Importer
 * Any changes will be lost, when it gets regenerated.
 * -----------------------------------------------------*/

using ExcelImporter.Editor.ExcelProcessing;
using ExcelImporter.Editor.Importers;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Game.Data.Imports
{
    public class TestDataWorkbookImporter
    {
        private const string ExcelFilePath = "Assets/Packages/ExcelImporter/TestData.xlsx";
        private const string ImportBasePath = "Assets/Data/Imports/";
        private const bool PrefixAssetName = true;

        [MenuItem("Tools/Excel Importer/Import TestDataWorkbookImporter", priority = 100)]
        public static void Import()
        {
            EditorUtility.DisplayProgressBar("Excel Importer", "Loading Workbook", 0f);
            var workbook = ExcelWorkbookFactory.Create(ExcelFilePath);

            EditorUtility.DisplayProgressBar("Excel Importer", "Importing Sheet: TestThingsImport", 1);
            HandleSheet<TestThingsImport, TestThingsImport.Row>(workbook, "TestThingsImport");



            EditorUtility.DisplayProgressBar("Excel Importer", "Saving Assets", 1f);
            AssetDatabase.SaveAssets();

            UnityEngine.Debug.Log($"Imported {workbook.Sheets.Count} sheets from {workbook.FilePath}");
            EditorUtility.ClearProgressBar();
        }

        private static void HandleSheet<TSheet, TRow>(ExcelWorkbook workbook, string sheetName)
            where TSheet : ScriptableObject
            where TRow : new()
        {
            var importFilename = GetImportFilePath(workbook, sheetName, ImportBasePath, PrefixAssetName);
            SheetImporter.ImportData<TSheet, TRow>(workbook, sheetName, importFilename);
        }

        private static string GetImportFilePath(ExcelWorkbook workbook, string sheetName, string importBasePath, bool prefixAssetName)
        {
            var prefix = prefixAssetName ? $"{workbook.Name}." : string.Empty;
            var filename = $"{prefix}{sheetName}.asset";

            return Path.Combine(importBasePath, filename);
        }
    }
}
