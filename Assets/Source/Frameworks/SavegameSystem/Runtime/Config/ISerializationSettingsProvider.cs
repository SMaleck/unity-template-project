using Newtonsoft.Json;

namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public interface ISerializationSettingsProvider
    {
        JsonSerializerSettings DefaultSettings { get; }
        JsonSerializerSettings CompressionSettings { get; }
    }
}