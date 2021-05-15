using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Storage.Processors
{
    public interface ISerializationProcessor
    {
        string Serialize(ISavegame savegame);
        ISavegame Deserialize(string savegameJson);
    }
}