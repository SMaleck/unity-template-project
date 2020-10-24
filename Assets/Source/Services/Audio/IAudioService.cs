using UnityEngine;

namespace Source.Services.Audio
{
    public interface IAudioService
    {
        void PlayMusic(MusicAudioClipId musicAudioClipId);
        void PlayEffect(EffectAudioClipId effectAudioClipId);
        void PlayEffectRandomized(EffectAudioClipId effectAudioClipId);

        void ResetAllPausedItems();
        void PauseAll();
        void PauseMusic();
        void PauseEffects();
        void UnPauseAll();
        void UnPauseMusic();
        void UnPauseEffects();
        void SetMusicVolume(float volume);
        void SetEffectsVolume(float volume);
    }
}