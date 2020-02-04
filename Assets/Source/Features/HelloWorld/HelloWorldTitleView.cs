using Source.Services.SceneTransition;
using TMPro;
using UGF.Services.Localization;
using UGF.Views;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Features.HelloWorld
{
    public class HelloWorldTitleView : AbstractView, ILocalizable
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, HelloWorldTitleView> { }

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
