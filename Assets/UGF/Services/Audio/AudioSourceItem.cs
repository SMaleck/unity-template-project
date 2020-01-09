using UGF.Util.Mono;
using UnityEngine;
using Zenject;

namespace UGF.Services.Audio
{
    public class AudioSourceItem : AbstractDisposableMonoBehaviour
    {
        public class AudioSourceItemSetupBundle
        {
            public AudioClip AudioClip { get; private set; }
            public float Volume { get; private set; }
            public float Pitch { get; private set; }
            public bool Loop { get; private set; }

            public AudioSourceItemSetupBundle(AudioClip audioClip, float volume, float pitch, bool loop)
            {
                AudioClip = audioClip;
                Volume = volume;
                Pitch = pitch;
                Loop = loop;
            }
        }

        public class Pool : MonoMemoryPool<AudioSourceItemSetupBundle, AudioSourceItem>
        {
            protected override void Reinitialize(AudioSourceItemSetupBundle audioSourceItemSetupBundle, AudioSourceItem audioSourceItem)
            {
                audioSourceItem.SetIsActive(true);
                audioSourceItem.Construct(audioSourceItemSetupBundle);
            }

            protected override void OnDespawned(AudioSourceItem audioSourceItem)
            {
                audioSourceItem.Stop();
                base.OnDespawned(audioSourceItem);
            }
        }

        [SerializeField] private AudioSource _audioSource;

        public bool IsPlaying => _audioSource.isPlaying;
        public bool IsPaused { get; private set; }

        public void Construct(AudioSourceItemSetupBundle audioSourceItemSetupBundle)
        {
            _audioSource.clip = audioSourceItemSetupBundle.AudioClip;
            _audioSource.volume = audioSourceItemSetupBundle.Volume;
            _audioSource.pitch = audioSourceItemSetupBundle.Pitch;
            _audioSource.loop = audioSourceItemSetupBundle.Loop;

            IsPaused = false;
        }

        public void Play()
        {
            IsPaused = false;
            _audioSource.Play();
        }

        public void Stop()
        {
            IsPaused = false;
            _audioSource.Stop();
        }

        public void Pause()
        {
            if (!IsPlaying || IsPaused) return;

            IsPaused = true;
            _audioSource.Pause();
        }

        public void UnPause()
        {
            if (!IsPaused) return;

            IsPaused = false;
            _audioSource.UnPause();
        }

        public void SetVolume(float volume)
        {
            _audioSource.volume = volume;
        }
    }
}
