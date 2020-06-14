using Source.Framework.Views;
using Source.Framework.Views.Mediation;
using Source.ServicesStatic.Localization;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Features.Hud
{
    public class HudView : AbstractView, ILocalizable
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, HudView> { }

        [SerializeField] private TextMeshProUGUI _helloWorldText;
        [SerializeField] private Button _openButton;

        private IClosableViewMediator _closableViewMediator;

        [Inject]
        private void Inject(IClosableViewMediator closableViewMediator)
        {
            _closableViewMediator = closableViewMediator;
        }

        public override void OnInitialize()
        {
            _openButton.OnClickAsObservable()
                .Subscribe(_ => _closableViewMediator.Open(ClosableViewType.HelloWorld))
                .AddTo(Disposer);
        }

        public void Localize()
        {
            _helloWorldText.text = TextService.HelloWorld();
        }
    }
}
