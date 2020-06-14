using Source.Framework.Services.Localization;
using Source.Framework.Views;
using Source.Services.SceneTransition;
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

        private ISceneTransitionService _sceneTransitionService;

        [Inject]
        private void Inject(ISceneTransitionService sceneTransitionService)
        {
            _sceneTransitionService = sceneTransitionService;
        }

        public override void OnInitialize()
        {
            _startButton.OnClickAsObservable()
                .Subscribe(_ => _sceneTransitionService.ToGame())
                .AddTo(Disposer);
        }

        public void Localize()
        {
            _helloWorldText.text = TextService.HelloWorld();
        }
    }
}
