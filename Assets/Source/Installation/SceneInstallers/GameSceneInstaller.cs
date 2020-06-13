using Source.Features.HelloWorld.Installation;
using Source.Framework.Installation;
using Source.Framework.Views.Mediation;
using Source.Initialization;

namespace Source.Installation.SceneInstallers
{
    public class GameSceneInstaller : AbstractSceneInstaller
    {
        protected override void InstallSceneBindings()
        {
            Container.BindInterfacesAndSelfTo<GameSceneInitializer>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<ClosableViewMediator>().AsSingle().NonLazy();
            Container.BindFactory<IClosableView, ClosableViewController, ClosableViewController.Factory>();

            HelloWorldInstaller.Install(Container);
        }
    }
}
