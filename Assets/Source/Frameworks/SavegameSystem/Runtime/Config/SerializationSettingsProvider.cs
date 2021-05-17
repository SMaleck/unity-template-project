using Newtonsoft.Json;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public class SerializationSettingsProvider : ISerializationSettingsProvider
    {
        public JsonSerializerSettings DefaultSettings { get; }
        public JsonSerializerSettings CompressionSettings { get; }

        public SerializationSettingsProvider(IJsonConvertersProvider convertersProvider)
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
