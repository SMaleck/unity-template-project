using Newtonsoft.Json;

namespace Source.Frameworks.SavegameSystem
{
    public static class SavegameSettings
    {
        public static string DefaultPath = "Assets/Packages/SavegameSystem/SavegameSettings.asset";


        // ToDo SAVE shouldn't be static, so we can include custom converters
        public static JsonSerializerSettings DefaultJsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Include,
            MissingMemberHandling = MissingMemberHandling.Error,
            ObjectCreationHandling = ObjectCreationHandling.Replace
        };

        public static JsonSerializerSettings CompressionJsonSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Include,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };
    }
}
