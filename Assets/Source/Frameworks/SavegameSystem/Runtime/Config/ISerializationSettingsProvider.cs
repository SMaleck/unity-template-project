using Newtonsoft.Json;

namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public interface ISerializationSettingsProvider
    {
        JsonSerializerSettings DefaultJsonSettings { get; }
        JsonSerializerSettings CompressionJsonSettings { get; }
    }
}