using System;
using System.Collections.Generic;
using System.Linq;
using Source.Frameworks;
using UnityEngine;

namespace Source.Services.Audio.Config
{
    [CreateAssetMenu(fileName = nameof(AudioServiceConfig), menuName = Constants.MenuRoot + nameof(AudioServiceConfig))]
    public class AudioServiceConfig : ScriptableObject
    {
        [Serializable]
        private class AudioChannelConfig
        {
            [SerializeField] private AudioChannel _audioChannel;
            public AudioChannel AudioChannel => _audioChannel;

            [SerializeField] private float _defaultVolume;
            public float DefaultVolume => _defaultVolume;
        }

        [SerializeField] private AudioSource _audioSourcePrefab;
        public AudioSource AudioSourcePrefab => _audioSourcePrefab;

        [Header("Pitch Randomization")]
        [SerializeField] private float _minPitch;
        public float MinPitch => _minPitch;

        [SerializeField] private float _maxPitch;
        public float MaxPitch => _maxPitch;

        [Header("Channel Configs")]
        [SerializeField] private List<AudioChannelConfig> _audioChannelConfigs;

        public float GetDefaultVolume(AudioChannel audioChannel)
        {
            return _audioChannelConfigs
                .First(config => config.AudioChannel == audioChannel)
                .DefaultVolume;
        }
    }
}
