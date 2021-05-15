using Newtonsoft.Json;
using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage.Processors
{
    public class SerializationProcessor : ISerializationProcessor
    {
        public SerializationProcessor()
        {
        }

        public string Serialize(ISavegame savegame)
        {
            return JsonConvert.SerializeObject(savegame);
        }

        public ISavegame Deserialize(string savegameJson)
        {
            return JsonConvert.DeserializeObject<ISavegame>(savegameJson);
        }
    }
}
