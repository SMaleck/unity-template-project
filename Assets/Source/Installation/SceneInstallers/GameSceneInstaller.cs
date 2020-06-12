using Source.Features.HelloWorld;
using Source.Framework.Installation;
using Source.Framework.Util;
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

            Container.BindPrefabFactory<HelloWorldHudView, HelloWorldHudView.Factory>();
            Container.BindPrefabFactory<HelloWorldGameView, HelloWorldGameView.Factory>();
        }
    }
}
