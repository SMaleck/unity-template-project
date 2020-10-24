using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Features.Hud
{
    public class HudView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _helloWorldText;
        public string HelloWorldText
        {
            set => _helloWorldText.text = value;
        }

        [SerializeField] private Button _openButton;
        public Button OpenButton => _openButton;
    }
}
