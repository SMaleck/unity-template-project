using System;
using System.Collections.Generic;
using System.Linq;
using Source.Frameworks;
using UnityEngine;

namespace Source.Services.Audio.Config
{
    [CreateAssetMenu(fileName = nameof(AudioClipsConfig), menuName = Constants.MenuRoot + nameof(AudioClipsConfig))]
    public class AudioClipsConfig : ScriptableObject, IAudioClipRepository<MusicAudioClipId>, IAudioClipRepository<EffectAudioClipId>
    {
        [Serializable]
        private class AudioClipItem<T> where T : Enum
        {
            [SerializeField] private T _clipId;
            public T ClipId => _clipId;

            [SerializeField] private AudioClip _audioClip;
            public AudioClip AudioClip => _audioClip;
        }

        [Serializable]
        private class MusicAudioClipItem : AudioClipItem<MusicAudioClipId> { }

        [Serializable]
        private class EffectAudioClipItem : AudioClipItem<EffectAudioClipId> { }

        [SerializeField] private List<MusicAudioClipItem> _musicAudioClipItems;
        [Space]
        [SerializeField] private List<EffectAudioClipItem> _effectAudioClipItems;

        public AudioClip GetAudioClip(MusicAudioClipId musicAudioClipId)
        {
            return _musicAudioClipItems
                .First(item => item.ClipId == musicAudioClipId)
                .AudioClip;
        }

        public AudioClip GetAudioClip(EffectAudioClipId effectAudioClipId)
        {
            return _effectAudioClipItems
                .First(item => item.ClipId == effectAudioClipId)
                .AudioClip;
        }
    }
}
