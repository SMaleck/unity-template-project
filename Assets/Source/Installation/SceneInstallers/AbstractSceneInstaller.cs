using Source.Framework.Initialization;
using Source.Framework.Services.SceneManagement;
using Source.Framework.Util;
using UniRx;
using Zenject;

namespace Source.Framework.Installation
{
    public abstract class AbstractSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<CompositeDisposable>()
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
