using Source.Framework.Util;
using Source.Framework.Util.DataStorageStrategies;
using Source.Initialization;
using Source.Services.Audio;
using Source.Services.Audio.Config;
using Source.Services.Savegames;
using Source.Services.SceneManagement;
using Source.Services.SceneManagement.LoadingScreen;
using Source.Services.SceneTransition;
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
            
            Container.BindInterfacesTo<SceneTransitionService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneManagementService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManagementModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingScreenModel>().AsSingle();
            Container.BindPrefabFactory<LoadingScreenView, LoadingScreenView.Factory>();
            
            SavegameInstaller.Install(Container);
            ServiceInstaller.Install(Container);
        }
    }
}
