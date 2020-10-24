using Source.Framework;
using UnityEngine;
using Zenject;

namespace Source.Features.HelloWorld.Installation
{
    [CreateAssetMenu(fileName = nameof(HelloWorldInstaller), menuName = Constants.InstallersMenu + nameof(HelloWorldInstaller))]
    public class HelloWorldInstaller : ScriptableObjectInstaller<HelloWorldInstaller>
    {
        [SerializeField] private HelloWorldGameView _helloWorldGameViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<HelloWorldGameView>().FromComponentInNewPrefab(_helloWorldGameViewPrefab)
                .AsSingle();

            Container.BindInterfacesTo<HelloWorldController>().AsSingle().NonLazy();
        }
    }
}
