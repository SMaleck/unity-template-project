using Newtonsoft.Json;
using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage.Processors
{
    public class SerializationProcessor : ISerializationProcessor
    {
        // ToDo SAVE JSON Settings
        public SerializationProcessor()
        {
        }

        public string Serialize<T>(ISavegame<T> savegame)
        {
            return JsonConvert.SerializeObject(savegame);
        }

        public Savegame<T> Deserialize<T>(string savegameJson)
        {
            return JsonConvert.DeserializeObject<Savegame<T>>(savegameJson);
        }
    }
}
