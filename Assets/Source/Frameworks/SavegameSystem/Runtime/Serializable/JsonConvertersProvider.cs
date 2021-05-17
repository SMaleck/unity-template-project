using Newtonsoft.Json;
using System.Collections.Generic;

namespace Source.Frameworks.SavegameSystem.Runtime.Serializable
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
