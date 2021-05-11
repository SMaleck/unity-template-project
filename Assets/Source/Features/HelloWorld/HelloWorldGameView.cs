using Source.Frameworks.ViewSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Features.HelloWorld
{
    public class HelloWorldGameView : ClosableView
    {
        [Header("Audio Test")]
        [SerializeField] private Button _playSoundEffectButton;
        [SerializeField] private Button _playSoundEffectRandomizedButton;
        [SerializeField] private Button _toggleMusicButton;

        public Button PlaySoundEffectButton => _playSoundEffectButton;
        public Button PlaySoundEffectRandomizedButton => _playSoundEffectRandomizedButton;
        public Button ToggleMusicButton => _toggleMusicButton;
    }
}
