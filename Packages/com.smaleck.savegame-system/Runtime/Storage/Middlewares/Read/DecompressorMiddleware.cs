using Newtonsoft.Json.Linq;
using SavegameSystem.Config;
using SavegameSystem.Logging;
using SavegameSystem.Utility;
using System;

namespace SavegameSystem.Storage.Middlewares.Read
{
    public class DecompressorMiddleware : AbstractStorageMiddleware, ISavegameReadMiddleware
    {
        private readonly ISavegameLogger _logger;
        private readonly ISavegameSettings _settings;

        public DecompressorMiddleware(
            ISavegameLogger logger,
            ISavegameSettings settings)
            : base(SavegameConstants.DecompressorExecutionOrder)
        {
            _logger = logger;
            _settings = settings;
        }

        public string Process(string savegameJson)
        {
            if (!_settings.UseCompression)
            {
                return savegameJson;
            }

            var savegame = JObject.Parse(savegameJson);
            savegame["Content"] = GetDecompressedContent(savegame);

            return savegame.ToString();
        }

        private JObject GetDecompressedContent(JObject savegame)
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
                _logger.Warn("Savegame Content was not a valid Base64 string, probably the savegame was not compressed. Returning as is.");
                return savegameContent;
            }
        }
    }
}
