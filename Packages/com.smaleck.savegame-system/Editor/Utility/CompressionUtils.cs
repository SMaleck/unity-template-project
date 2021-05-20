using SavegameSystem.Logging;
using SavegameSystem.Storage.Middlewares.Read;

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

            var logger = new DefaultSavegameLogger();
            var decompressionMiddleware = new DecompressorMiddleware(logger);

            return decompressionMiddleware.Process(savegameJson);
        }
    }
}
