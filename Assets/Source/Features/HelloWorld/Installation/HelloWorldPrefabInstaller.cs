using Source.Framework;
using Source.Framework.Util;
using UnityEngine;
using Zenject;

namespace Source.Features.HelloWorld.Installation
{
    [CreateAssetMenu(fileName = nameof(HelloWorldPrefabInstaller), menuName = Constants.InstallersMenu + nameof(HelloWorldPrefabInstaller))]
    public class HelloWorldPrefabInstaller : ScriptableObjectInstaller<HelloWorldPrefabInstaller>
    {
        [SerializeField] private HelloWorldHudView _helloWorldView;
        [SerializeField] private HelloWorldGameView _helloWorldGameView;

        public override void InstallBindings()
        {
            //Container.BindInstance(_helloWorldView);
            //Container.BindInstance(_helloWorldGameView);

            Container.BindPrefabFactory<HelloWorldHudView, HelloWorldHudView.Factory>();
            Container.BindPrefabFactory<HelloWorldGameView, HelloWorldGameView.Factory>();
        }
    }
}
