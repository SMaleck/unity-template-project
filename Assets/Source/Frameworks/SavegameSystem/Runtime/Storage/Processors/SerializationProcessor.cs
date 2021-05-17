using Newtonsoft.Json;
using Source.Frameworks.SavegameSystem.Runtime.Config;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Processors
{
    public class SerializationProcessor : ISerializationProcessor
    {
        private readonly ISerializationSettingsProvider _serializationSettingsProvider;

        public SerializationProcessor(ISerializationSettingsProvider serializationSettingsProvider)
        {
            _serializationSettingsProvider = serializationSettingsProvider;
        }

        public string Serialize<T>(ISavegame<T> savegame)
        {
            return JsonConvert.SerializeObject(
                savegame,
                _serializationSettingsProvider.DefaultJsonSettings);
        }

        public Savegame<T> Deserialize<T>(string savegameJson)
        {
            return JsonConvert.DeserializeObject<Savegame<T>>(
                savegameJson,
                _serializationSettingsProvider.DefaultJsonSettings);
        }
    }
}
