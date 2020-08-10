using Source.Framework.Logging;
using Source.Framework.Util;
using Source.Initialization;
using Source.Services.SceneManagement;
using Source.Services.SceneManagement.LoadingScreen;
using UnityEngine;
using Zenject;

namespace Source.Installation
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;

            Container.BindExecutionOrder<ISceneInitializer>(998);
            Container.BindInterfacesAndSelfTo<ProjectInitializer>().AsSingle().NonLazy();

            Container.BindInterfacesTo<InstanceLogger>().AsSingle();

            Container.BindInterfacesAndSelfTo<SceneManagementService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManagementModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingScreenModel>().AsSingle();
            Container.BindPrefabFactory<LoadingScreenView, LoadingScreenView.Factory>();

            ServiceInstaller.Install(Container);
        }
    }
}
