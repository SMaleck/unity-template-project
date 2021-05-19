using SavegameSystem.Serializable;

namespace SavegameSystem.Storage.Serialization
{
    public interface ISerializationProcessor
    {
        string Serialize<T>(ISavegame<T> savegame);
        Savegame<T> Deserialize<T>(string savegameJson);
    }
}