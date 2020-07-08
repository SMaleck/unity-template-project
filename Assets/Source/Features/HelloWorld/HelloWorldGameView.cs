using Source.Framework.Views;
using Source.Services.Audio;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Features.HelloWorld
{
    public class HelloWorldGameView : AbstractView
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, HelloWorldGameView> { }

        [Header("Audio Test")]
        [SerializeField] private Button _playSoundEffectButton;
        [SerializeField] private Button _playSoundEffectRandomizedButton;
        [SerializeField] private Button _toggleMusicButton;

        private IAudioService _audioService;

        [Inject]
        private void Inject(IAudioService audioService)
        {
            _audioService = audioService;
        }

        public override void OnInitialize()
        {
            _playSoundEffectButton.OnClickAsObservable()
                .Subscribe(_ => _audioService.PlayEffect(EffectAudioClipId.Default))
                .AddTo(Disposer);

            _playSoundEffectRandomizedButton.OnClickAsObservable()
                .Subscribe(_ => _audioService.PlayEffectRandomized(EffectAudioClipId.Default))
                .AddTo(Disposer);

            _toggleMusicButton.OnClickAsObservable()
                .Subscribe(_ => _audioService.PlayMusic(MusicAudioClipId.Default))
                .AddTo(Disposer);
        }
    }
}
