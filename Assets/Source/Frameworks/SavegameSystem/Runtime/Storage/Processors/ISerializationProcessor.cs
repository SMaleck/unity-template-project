using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage.Processors
{
    public interface ISerializationProcessor
    {
        string Serialize<T>(ISavegame<T> savegame);
        Savegame<T> Deserialize<T>(string savegameJson);
    }
}