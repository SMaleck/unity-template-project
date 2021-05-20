using System;
using UnityEngine;

namespace SavegameSystem.Settings
{
    public class SavegameSettings : ScriptableObject, ISavegameSettings
    {
        public static string SettingsPath = "Assets/Packages/SavegameSystem/SavegameSystemSettings.asset";

        [SerializeField] private SavegamePath _savegamePath;
        public string Path => GetPath();
        
        [SerializeField] private string _savegameFilename;
        public string Filename => _savegameFilename;
        
        [SerializeField] private bool _useCompression;
        public bool UseCompression => _useCompression;

        public void Reset()
        {
            _savegameFilename = "player.sav";
            _useCompression = true;
        }

        private string GetPath()
        {
            switch (_savegamePath)
            {
                case SavegamePath.DataPath:
                    return Application.dataPath;

                case SavegamePath.PersistentDataPath:
                    return Application.persistentDataPath;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
