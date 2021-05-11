﻿using System.IO;
using Newtonsoft.Json;

namespace Source.Utilities.Json
{
    public static class JsonStorage
    {
        public static T Read<T>(string filename) where T : class
        {
            if (!File.Exists(filename))
            {
                return null;
            }

            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static void Write<T>(string filename, T data)
        {
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText(filename, json);
        }
    }
}
