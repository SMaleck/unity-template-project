using Source.Framework.Initialization;
using Source.Framework.Util;
using Source.Framework.Util.DataStorageStrategies;
using Source.Initialization;
using Source.Services.Audio;
using Source.Services.Audio.Config;
using Source.Services.AudioPlayer;
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
        [Inject] private AudioServiceConfig _audioServiceConfig;

        public override void InstallBindings()
        {
            Application.targetFrameRate = 60;

            Container.BindExecutionOrder<ISceneInitializer>(998);
            Container.BindInterfacesAndSelfTo<ProjectInitializer>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<JsonDataStorageStrategy>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegameService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegamePersistenceScheduler>().AsSingle();

            Container.BindInterfacesAndSelfTo<SceneManagementService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SceneManagementModel>().AsSingle();
            Container.BindInterfacesAndSelfTo<LoadingScreenModel>().AsSingle();
            Container.BindPrefabFactory<LoadingScreenView, LoadingScreenView.Factory>();

            Container.BindMemoryPool<AudioSourceItem, AudioSourceItem.Pool>()
                .FromComponentInNewPrefab(_audioServiceConfig.AudioSourcePrefab)
                .UnderTransformGroup("Audio");

            Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();

            Container.BindInterfacesAndSelfTo<AudioPlayerService>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<SceneTransitionService>().AsSingle().NonLazy();

            ServiceInstaller.Install(Container);
        }
    }
}
