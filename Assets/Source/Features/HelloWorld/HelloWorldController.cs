using Source.Frameworks.ViewSystem;
using Source.Services.Audio;
using UniRx;

namespace Source.Features.HelloWorld
{
    public class HelloWorldController : ClosableViewController<HelloWorldGameView>
    {
        private readonly HelloWorldGameView _view;
        private readonly IAudioService _audioService;

        public HelloWorldController(
            HelloWorldGameView view,
            IAudioService audioService)
            : base(view)
        {
            _view = view;
            _audioService = audioService;
        }

        protected override void OnInitialize()
        {
            _view.PlaySoundEffectButton.OnClickAsObservable()
                .Subscribe(_ => _audioService.PlayEffect(EffectAudioClipId.Default))
                .AddTo(Disposer);

            _view.PlaySoundEffectRandomizedButton.OnClickAsObservable()
                .Subscribe(_ => _audioService.PlayEffectRandomized(EffectAudioClipId.Default))
                .AddTo(Disposer);

            _view.ToggleMusicButton.OnClickAsObservable()
                .Subscribe(_ => _audioService.PlayMusic(MusicAudioClipId.Default))
                .AddTo(Disposer);
        }
    }
}
