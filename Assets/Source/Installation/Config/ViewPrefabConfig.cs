using Source.Features.HelloWorld;
using Source.Features.TitleScreen;
using Source.Framework;
using UnityEngine;

namespace Source.Installation.Config
{
    [CreateAssetMenu(fileName = nameof(ViewPrefabConfig), menuName = Constants.MenuRoot + nameof(ViewPrefabConfig))]
    public class ViewPrefabConfig : ScriptableObject
    {
        [SerializeField] private TitleScreenView _titleScreenViewPrefab;
        public TitleScreenView TitleScreenViewPrefab => _titleScreenViewPrefab;

        [SerializeField] private HelloWorldHudView _helloWorldHudViewPrefab;
        public HelloWorldHudView HelloWorldHudViewPrefab => _helloWorldHudViewPrefab;

        [SerializeField] private HelloWorldGameView _helloWorldGameViewPrefab;
        public HelloWorldGameView HelloWorldGameViewPrefab => _helloWorldGameViewPrefab;
    }
}
