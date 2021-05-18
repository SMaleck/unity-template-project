using System.Collections.Generic;
using Newtonsoft.Json;

namespace SavegameSystem.Serializable
{
    public class JsonConvertersProvider : IJsonConvertersProvider
    {
        private readonly List<JsonConverter> _converters;

        public JsonConvertersProvider()
        {
            _converters = new List<JsonConverter>();
        }

        public List<JsonConverter> GetConverters()
        {
            return _converters;
        }
    }
}
