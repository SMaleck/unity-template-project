using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnityEngine;

namespace Source.Services.Savegames.Read
{
    public class LocalReader
    {
        private readonly string _basePath;

        public LocalReader()
        {
            _basePath = Application.persistentDataPath;
        }

        public T Load<T>(string filename) where T : class
        {
            var filePath = GetFilePath(filename);
            Logger.Log($"Loading savegame from {filePath}");

            if (!File.Exists(filePath))
            {
                return null;
            }

            string json = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public void Save<T>(string filename, T data)
        {
            var filePath = GetFilePath(filename);
            Logger.Log($"Saving savegame to {filePath}");

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filePath, json);
        }

        private string GetFilePath(string filename)
        {
            return Path.Combine(_basePath, $"{filename}");
        }
    }
}
