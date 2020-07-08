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
        }
    }
}
