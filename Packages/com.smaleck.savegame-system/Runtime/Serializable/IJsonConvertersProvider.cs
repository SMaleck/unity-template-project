using System.Collections.Generic;
using Newtonsoft.Json;

namespace SavegameSystem.Serializable
{
    public interface IJsonConvertersProvider
    {
        List<JsonConverter> GetConverters();
    }
}
