﻿using UnityEngine;

namespace SavegameSystem.Config
{
    public class SavegameSettings : ScriptableObject, ISavegameSettings
    {
        [SerializeField] private string _savegameFilename = "player.sav";
        public string Filename => _savegameFilename;

        [SerializeField] private bool _useCompression;
        public bool UseCompression => _useCompression;
    }
}