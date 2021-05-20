using SavegameSystem.Storage.ResourceProviders;

namespace Source.Services.SavegameSystem
{
    public class SavegameResourcesProvider : ISavegameClientVersionProvider, ISavegameVersionProvider
    {
        // This is a basic stub and should not be used like this

        public string ClientVersion => "1.0.0";
        public string ClientBuild => "123";
        public int Version => 1;
    }
}
