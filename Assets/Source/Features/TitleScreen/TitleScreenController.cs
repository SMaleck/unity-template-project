using Packages.RxUtils;
using Source.Services.SceneManagement;
using Source.ServicesStatic.Localization;
using UniRx;
using Zenject;

namespace Source.Features.TitleScreen
{
    public class TitleScreenController : AbstractDisposable, IInitializable, ILocalizable
    {
        private readonly TitleScreenView _view;
        private readonly ISceneManagementService _sceneManagementService;

        public TitleScreenController(
            TitleScreenView view,
            ISceneManagementService sceneManagementService)
        {
            _view = view;
            _sceneManagementService = sceneManagementService;
        }

        public void Initialize()
        {
            _view.StartButton.OnClickAsObservable()
                .Subscribe(_ => _sceneManagementService.ToGame())
                .AddTo(Disposer);
        }

        public void Localize()
        {
            _view.HelloWorldText = TextService.HelloWorld();
        }
    }
}
