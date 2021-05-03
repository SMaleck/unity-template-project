using System.Collections.Generic;
using UnityEngine;

namespace ExcelImporter.Runtime.Imports
{
    public abstract class AbstractImport<T> : ScriptableObject
    {
        public List<T> Rows;

        protected AbstractImport()
        {
            Rows = new List<T>();
        }
    }
}
