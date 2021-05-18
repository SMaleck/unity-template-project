using Newtonsoft.Json;

namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public interface ISerializationSettings
    {
        JsonSerializerSettings DefaultSettings { get; }
        JsonSerializerSettings CompressionSettings { get; }
    }
}