using Newtonsoft.Json;
using System.Collections.Generic;

namespace Source.Frameworks.SavegameSystem.Runtime.Serializable
{
    public interface IJsonConvertersProvider
    {
        List<JsonConverter> GetConverters();
    }
}
