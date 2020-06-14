using Source.Framework.Util;
using Zenject;

namespace Source.Features.HelloWorld.Installation
{
    public class HelloWorldInstaller : Installer<HelloWorldInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindPrefabFactory<HelloWorldGameView, HelloWorldGameView.Factory>();
        }
    }
}
