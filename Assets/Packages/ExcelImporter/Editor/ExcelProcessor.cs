using ExcelImporter.Editor.Processing;
using ExcelImporter.Editor.Utility;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using ExcelImporter.Editor.CodeGenerators;

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
                ImporterCodeGenerator.Generate(excelWorkbook);

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
