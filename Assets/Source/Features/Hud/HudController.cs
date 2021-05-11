using Source.Features.HelloWorld;
using Source.Frameworks.ViewSystem;
using Source.ServicesStatic.Localization;
using Source.Utilities.Reactive;
using UniRx;
using Zenject;

namespace Source.Features.Hud
{
    public class HudController : AbstractDisposable, IInitializable, ILocalizable
    {
        private readonly HudView _view;
        private readonly IClosableViewMediator _closableViewMediator;

        public HudController(
            HudView view,
            IClosableViewMediator closableViewMediator)
        {
            _view = view;
            _closableViewMediator = closableViewMediator;
        }

        public void Initialize()
        {
            _view.OpenButton.OnClickAsObservable()
                .Subscribe(_ => _closableViewMediator.Open<HelloWorldGameView>())
                .AddTo(Disposer);
        }

        public void Localize()
        {
            _view.HelloWorldText = TextService.HelloWorld();
        }
    }
}
