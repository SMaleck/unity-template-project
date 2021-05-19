using Newtonsoft.Json.Linq;
using SavegameSystem.Config;
using SavegameSystem.Utility;

namespace SavegameSystem.Storage.Middlewares.Read
{
    public class DecompressorMiddleware : AbstractStorageMiddleware, ISavegameReadMiddleware
    {
        private readonly ISavegameSettings _settings;

        public DecompressorMiddleware(ISavegameSettings settings) 
            : base(SavegameConstants.DecompressorExecutionOrder)
        {
            _settings = settings;
        }

        // ToDo SAVE handle previously uncompressed savegame
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
            var contentJson = savegame["Content"].ToString();
            var decompressedContent = GzipCompressor.Decompress(contentJson);

            return JObject.Parse(decompressedContent);
        }
    }
}
