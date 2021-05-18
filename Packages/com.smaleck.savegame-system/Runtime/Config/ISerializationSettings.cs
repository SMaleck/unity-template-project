using Newtonsoft.Json;

namespace SavegameSystem.Config
{
    public interface ISerializationSettings
    {
        JsonSerializerSettings DefaultSettings { get; }
        JsonSerializerSettings CompressionSettings { get; }
    }
}