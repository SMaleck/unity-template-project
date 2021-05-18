using Source.Frameworks.SavegameSystem.Runtime.Serializable;

namespace Source.Frameworks.SavegameSystem.Runtime.Storage.Processors
{
    public interface ISerializationProcessor
    {
        string Serialize<T>(ISavegame<T> savegame);
        Savegame<T> Deserialize<T>(string savegameJson);
    }
}