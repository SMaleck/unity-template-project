using Source.Framework.Util;
using Source.Framework.Views;
using Source.Initialization;
using Source.Services.SceneManagement;
using UniRx;
using Zenject;

namespace Source.Installation.SceneInstallers
{
    public abstract class AbstractSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CompositeDisposable>()
                .AsSingleNonLazy();

            Container.BindInterfacesAndSelfTo<ClosableViewFactory>()
                .AsSingleNonLazy();

            InstallSceneBindings();
            PostInstall();
        }

        protected abstract void InstallSceneBindings();

        private void PostInstall()
        {
            Container.BindExecutionOrder<ISceneInitializer>(998);

            Container.BindExecutionOrder<SceneStartController>(999);
            Container.BindInterfacesAndSelfTo<SceneStartController>().AsSingle().NonLazy();
        }
    }
}
