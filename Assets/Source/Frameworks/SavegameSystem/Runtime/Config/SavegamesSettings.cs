using UnityEngine;

namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public class SavegamesSettings : ScriptableObject, ISavegameSettings
    {
        [SerializeField] private string _savegameFilename = "player.sav";
        public string Filename => _savegameFilename;

        [SerializeField] private bool _useCompression;
        public bool UseCompression => _useCompression;
    }
}
