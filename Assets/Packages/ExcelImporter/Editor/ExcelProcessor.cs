using ExcelImporter.Editor.CodeGenerators;
using ExcelImporter.Editor.ExcelProcessing;
using ExcelImporter.Editor.Utility;
using System;
using System.Collections.Generic;

namespace ExcelImporter.Editor
{
    internal static class ExcelProcessor
    {
        public static void Process(IEnumerable<string> excelPaths)
        {
            foreach (var path in excelPaths)
            {
                Process(path);
            }
        }

        public static void Process(string excelPath)
        {
            try
            {
                EditorUtils.Progress("Loading Excel", 0.0f);
                var excelWorkbook = ExcelWorkbookFactory.Create(excelPath);

                EditorUtils.Progress("Generating Code", 0.5f);
                CodeGenerator.Generate(excelWorkbook);

                EditorUtils.ProgressClear();
                UnityEngine.Debug.Log($"Successfully processed {excelPath}");
            }
            catch (Exception e)
            {
                EditorUtils.ErrorProcessingExcelFailed(e);
                EditorUtils.ProgressClear();
            }
        }
    }
}
