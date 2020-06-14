using Source.Framework;
using UnityEngine;

namespace Source.Features.HelloWorld.Config
{
    [CreateAssetMenu(fileName = nameof(HelloWorldPrefabConfig), menuName = Constants.ConfigMenu + nameof(HelloWorldPrefabConfig))]
    public class HelloWorldPrefabConfig : ScriptableObject
    {
        [SerializeField] private HelloWorldGameView _helloWorldGameViewPrefab;
        public HelloWorldGameView HelloWorldGameViewPrefab => _helloWorldGameViewPrefab;
    }
}
