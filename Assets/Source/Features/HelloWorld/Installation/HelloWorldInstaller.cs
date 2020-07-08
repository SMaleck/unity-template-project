using Source.Features.HelloWorld.Config;
using Source.Framework;
using Source.Framework.Util;
using UnityEngine;
using Zenject;

namespace Source.Features.HelloWorld.Installation
{
    [CreateAssetMenu(fileName = nameof(HelloWorldInstaller), menuName = Constants.InstallersMenu + nameof(HelloWorldInstaller))]
    public class HelloWorldInstaller : ScriptableObjectInstaller<HelloWorldInstaller>
    {
        [SerializeField] private HelloWorldPrefabConfig _helloWorldPrefabConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_helloWorldPrefabConfig);

            Container.BindPrefabFactory<HelloWorldGameView, HelloWorldGameView.Factory>();
        }
    }
}
