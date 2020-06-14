using Source.Framework;
using UnityEngine;

namespace Source.Features.HelloWorld.Config
{
    [CreateAssetMenu(fileName = nameof(HelloWorldPrefabConfig), menuName = Constants.InstallersMenu + nameof(HelloWorldPrefabConfig))]
    public class HelloWorldPrefabConfig : ScriptableObject
    {
        [SerializeField] private HelloWorldHudView _helloWorldHudViewPrefab;
        public HelloWorldHudView HelloWorldHudViewPrefab => _helloWorldHudViewPrefab;

        [SerializeField] private HelloWorldGameView _helloWorldGameViewPrefab;
        public HelloWorldGameView HelloWorldGameViewPrefab => _helloWorldGameViewPrefab;
    }
}
