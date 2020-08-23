using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Source.Features.TitleScreen
{
    public class TitleScreenView : MonoBehaviour
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, TitleScreenView> { }

        [SerializeField] private TextMeshProUGUI _helloWorldText;
        [SerializeField] private Button _startButton;

        public Button StartButton => _startButton;

        public string HelloWorldText
        {
            set => _helloWorldText.text = value;
        }
    }
}
