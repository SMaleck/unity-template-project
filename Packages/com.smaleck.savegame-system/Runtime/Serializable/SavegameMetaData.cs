using System;

namespace SavegameSystem.Serializable
{
    [Serializable]
    public class SavegameMetaData
    {
        // ToDo SAVE add ID Provider and set this
        public string Id { get; set; }

        // ToDo SAVE add Version Provider and set this
        public int Version { get; set; }
        
        public DateTime CreatedAtUtc { get; set; }
        public DateTime UpdatedAtUtc { get; set; }

        // ToDo SAVE add Client version and Build Provider and set this
        public string CreatedAtClientVersion { get; set; }
        public string CreatedAtClientBuild { get; set; }
        
        public string ClientVersion { get; set; }
        public string ClientBuild { get; set; }
    }
}
