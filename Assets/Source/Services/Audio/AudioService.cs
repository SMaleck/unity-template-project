using Source.Framework.Util;
using Source.Services.Audio.Config;
using Source.Services.Random;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Source.Services.Audio
{
    public class AudioService : IAudioService
    {
        private const float DefaultPitch = 1;

        private readonly AudioServiceConfig _audioServiceConfig;
        private readonly AudioSourceItem.Pool _audioSourceItemPool;
        private readonly IAudioClipRepository<MusicAudioClipId> _musicRepository;
        private readonly IAudioClipRepository<EffectAudioClipId> _effectsRepository;
        private readonly IRandomNumberService _randomNumberService;

        private readonly Dictionary<AudioChannel, List<AudioSourceItem>> _audioChannels;
        private readonly Dictionary<AudioChannel, float> _channelVolumes;

        public AudioService(
            AudioServiceConfig audioServiceConfig,
            AudioSourceItem.Pool audioSourceItemPool,
            IAudioClipRepository<MusicAudioClipId> musicRepository,
            IAudioClipRepository<EffectAudioClipId> effectsRepository,
            IRandomNumberService randomNumberService)
        {
            _audioServiceConfig = audioServiceConfig;
            _audioSourceItemPool = audioSourceItemPool;
            _musicRepository = musicRepository;
            _effectsRepository = effectsRepository;
            _randomNumberService = randomNumberService;

            _audioChannels = EnumHelper<AudioChannel>.Iterator
                .ToDictionary(
                    audioChannel => audioChannel,
                    audioChannel => new List<AudioSourceItem>());

            _channelVolumes = EnumHelper<AudioChannel>.Iterator
                .ToDictionary(
                    audioChannel => audioChannel,
                    _audioServiceConfig.GetDefaultVolume);
        }

        private void PlayClip(AudioChannel audioChannel, AudioClip audioClip, float pitch, bool loop)
        {
            CleanupChannels();

            var audioSourceItem = _audioSourceItemPool.Spawn(
                audioClip,
                _channelVolumes[audioChannel],
                pitch,
                loop);

            audioSourceItem.Play();
            _audioChannels[audioChannel].Add(audioSourceItem);
        }

        private void CleanupChannels()
        {
            _audioChannels.Values
                .ToList()
                .ForEach(DespawnCompletedAudioSourceItems);
        }

        private void DespawnCompletedAudioSourceItems(List<AudioSourceItem> audioSourceItems)
        {
            audioSourceItems
                .Where(audioSourceItem => !audioSourceItem.IsPlaying)
                .ToList()
                .ForEach(audioSourceItem =>
                {
                    _audioSourceItemPool.Despawn(audioSourceItem);
                    audioSourceItems.Remove(audioSourceItem);
                });
        }

        #region PLAY INTERFACE

        public void PlayMusic(MusicAudioClipId musicAudioClipId)
        {
            var audioClip = _musicRepository.GetAudioClip(musicAudioClipId);
            PlayClip(AudioChannel.Music, audioClip, DefaultPitch, true);
        }

        public void PlayEffect(EffectAudioClipId effectAudioClipId)
        {
            var audioClip = _effectsRepository.GetAudioClip(effectAudioClipId);
            PlayClip(AudioChannel.Effects, audioClip, DefaultPitch, false);
        }

        public void PlayEffectRandomized(EffectAudioClipId effectAudioClipId)
        {
            var audioClip = _effectsRepository.GetAudioClip(effectAudioClipId);
            float pitch = _randomNumberService.Range(_audioServiceConfig.MinPitch, _audioServiceConfig.MaxPitch);

            PlayClip(AudioChannel.Effects, audioClip, pitch, false);
        }

        #endregion


        #region PAUSE / UNPAUSE INTERFACE

        public void ResetAllPausedItems()
        {
            _audioChannels.Values
                .SelectMany(audioSourceItems => audioSourceItems)
                .Where(audioSourceItem => audioSourceItem.IsPaused)
                .ToList()
                .ForEach(audioSourceItem => audioSourceItem.Stop());
        }

        public void PauseAll()
        {
            _audioChannels.Values
                .SelectMany(audioSourceItems => audioSourceItems)
                .ToList()
                .ForEach(audioSourceItem => audioSourceItem.Pause());
        }

        public void PauseMusic()
        {
            PauseChannel(AudioChannel.Music);
        }

        public void PauseEffects()
        {
            PauseChannel(AudioChannel.Effects);
        }

        private void PauseChannel(AudioChannel audioChannel)
        {
            _audioChannels[audioChannel]
                .ForEach(audioSourceItem => audioSourceItem.Pause());
        }

        public void UnPauseAll()
        {
            _audioChannels.Values
                .SelectMany(audioSourceItems => audioSourceItems)
                .ToList()
                .ForEach(audioSourceItem => audioSourceItem.UnPause());
        }

        public void UnPauseMusic()
        {
            UnPauseChannel(AudioChannel.Music);
        }

        public void UnPauseEffects()
        {
            UnPauseChannel(AudioChannel.Effects);
        }

        private void UnPauseChannel(AudioChannel audioChannel)
        {
            _audioChannels[audioChannel]
                .ForEach(audioSourceItem => audioSourceItem.UnPause());
        }

        #endregion


        #region VOLUME INTERFACE

        public void SetMusicVolume(float volume)
        {
            UpdateChannelVolume(AudioChannel.Music, volume);
        }

        public void SetEffectsVolume(float volume)
        {
            UpdateChannelVolume(AudioChannel.Effects, volume);
        }

        private void UpdateChannelVolume(AudioChannel audioChannel, float volume)
        {
            _channelVolumes[audioChannel] = volume;

            _audioChannels[audioChannel]
                .ForEach(audioSourceItem => audioSourceItem.SetVolume(volume));
        }

        #endregion
    }
}
