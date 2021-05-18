using Newtonsoft.Json;
using SavegameSystem.Serializable;

namespace SavegameSystem.Config
{
    public class SerializationSettings : ISerializationSettings
    {
        public JsonSerializerSettings DefaultSettings { get; }
        public JsonSerializerSettings CompressionSettings { get; }

        public SerializationSettings(IJsonConvertersProvider convertersProvider)
        {
            DefaultSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Error,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                Converters = convertersProvider.GetConverters()
            };

            CompressionSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Converters = convertersProvider.GetConverters()
            };
        }
    }
}
