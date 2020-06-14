using Source.Features.HelloWorld.Config;
using Source.Framework;
using UnityEngine;
using Zenject;

namespace Source.Features.HelloWorld.Installation
{
    [CreateAssetMenu(fileName = nameof(HelloWorldSoInstaller), menuName = Constants.InstallersMenu + nameof(HelloWorldSoInstaller))]
    public class HelloWorldSoInstaller : ScriptableObjectInstaller<HelloWorldSoInstaller>
    {
        [SerializeField] private HelloWorldPrefabConfig _helloWorldPrefabConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_helloWorldPrefabConfig);
        }
    }
}
