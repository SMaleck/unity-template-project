using Newtonsoft.Json.Linq;
using SavegameSystem.Utility;
using System;

namespace SavegameSystem.Editor.Utility
{
    public static class CompressionUtils
    {
        public static string Decompress(string savegameJson)
        {
            if (string.IsNullOrWhiteSpace(savegameJson))
            {
                return "INVALID JSON";
            }

            var savegame = JObject.Parse(savegameJson);
            savegame["Content"] = GetDecompressedContent(savegame);

            return savegame.ToString();
        }

        private static JObject GetDecompressedContent(JObject savegame)
        {
            var savegameContent = (JObject)savegame["Content"];
            try
            {
                var contentJson = savegameContent?.ToString();
                var decompressedContent = GzipCompressor.Decompress(contentJson);

                return JObject.Parse(decompressedContent);
            }
            catch (FormatException)
            {
                UnityEngine.Debug.LogWarning("Savegame Content was not a valid Base64 string, probably the savegame was not compressed. Returning as is.");
                return savegameContent;
            }
        }
    }
}
