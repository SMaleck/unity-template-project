using Newtonsoft.Json;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public class SerializationSettingsProvider : ISerializationSettingsProvider
    {
        public JsonSerializerSettings DefaultJsonSettings { get; }
        public JsonSerializerSettings CompressionJsonSettings { get; }

        public SerializationSettingsProvider(IJsonConvertersProvider convertersProvider)
        {
            DefaultJsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Error,
                ObjectCreationHandling = ObjectCreationHandling.Replace,
                Converters = convertersProvider.GetConverters()
            };

            CompressionJsonSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Include,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                Converters = convertersProvider.GetConverters()
            };
        }
    }
}
