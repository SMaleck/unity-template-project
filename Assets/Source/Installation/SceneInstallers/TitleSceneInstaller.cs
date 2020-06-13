using Source.Features.TitleScreen;
using Source.Features.TitleScreen.Installation;
using Source.Framework.Installation;
using Source.Framework.Util;
using Source.Framework.Views.Mediation;
using Source.Initialization;

namespace Source.Installation.SceneInstallers
{
    public class TitleSceneInstaller : AbstractSceneInstaller
    {
        protected override void InstallSceneBindings()
        {
            Container.BindInterfacesAndSelfTo<TitleSceneInitializer>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<ClosableViewMediator>().AsSingle().NonLazy();
            Container.BindFactory<IClosableView, ClosableViewController, ClosableViewController.Factory>();

            TitleScreenInstaller.Install(Container);
        }
    }
}