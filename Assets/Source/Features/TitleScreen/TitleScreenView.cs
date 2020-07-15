using Source.Framework.Views;
using Source.Services.SceneManagement;
using Source.ServicesStatic.Localization;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Features.TitleScreen
{
    public class TitleScreenView : AbstractView, ILocalizable
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, TitleScreenView> { }

        [SerializeField] private TextMeshProUGUI _helloWorldText;
        [SerializeField] private Button _startButton;

        private ISceneManagementService _sceneManagementService;

        [Inject]
        private void Inject(ISceneManagementService sceneManagementService)
        {
            _sceneManagementService = sceneManagementService;
        }

        public override void OnInitialize()
        {
            _startButton.OnClickAsObservable()
                .Subscribe(_ => _sceneManagementService.ToGame())
                .AddTo(Disposer);
        }

        public void Localize()
        {
            _helloWorldText.text = TextService.HelloWorld();
        }
    }
}
