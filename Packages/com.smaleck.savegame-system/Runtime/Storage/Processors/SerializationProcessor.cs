using Newtonsoft.Json;
using SavegameSystem.Config;
using SavegameSystem.Serializable;

namespace SavegameSystem.Storage.Processors
{
    public class SerializationProcessor : ISerializationProcessor
    {
        private readonly ISerializationSettings _serializationSettings;

        public SerializationProcessor(ISerializationSettings serializationSettings)
        {
            _serializationSettings = serializationSettings;
        }

        public string Serialize<T>(ISavegame<T> savegame)
        {
            return JsonConvert.SerializeObject(
                savegame,
                _serializationSettings.DefaultSettings);
        }

        public Savegame<T> Deserialize<T>(string savegameJson)
        {
            return JsonConvert.DeserializeObject<Savegame<T>>(
                savegameJson,
                _serializationSettings.DefaultSettings);
        }
    }
}
