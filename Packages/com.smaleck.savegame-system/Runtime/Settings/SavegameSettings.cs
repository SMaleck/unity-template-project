using UnityEngine;

namespace SavegameSystem.Settings
{
    public class SavegameSettings : ScriptableObject, ISavegameSettings
    {
        public static string SettingsPath = "Assets/Packages/SavegameSystem/SavegameSystemSettings.asset";

        [SerializeField] private string _savegameFilename;
        public string Filename => _savegameFilename;

        [SerializeField] private bool _useCompression;
        public bool UseCompression => _useCompression;

        public void Reset()
        {
            _savegameFilename = "player.sav";
            _useCompression = true;
        }
    }
}
