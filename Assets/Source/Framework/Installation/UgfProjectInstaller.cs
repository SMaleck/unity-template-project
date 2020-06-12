using Source.Framework.Initialization;
using Source.Framework.Services.Audio;
using Source.Framework.Services.Audio.Config;
using Source.Framework.Services.Savegames;
using Source.Framework.Services.SceneManagement;
using Source.Framework.Services.SceneManagement.LoadingScreen;
using Source.Framework.Util;
using Source.Framework.Util.DataStorageStrategies;
using Zenject;

namespace Source.Framework.Installation
{
    public class UgfProjectInstaller : MonoInstaller
    {
        [Inject] private AudioServiceConfig _audioServiceConfig;

        public override void InstallBindings()
        {
            Container.BindExecutionOrder<ISceneInitializer>(998);
            Container.BindInterfacesAndSelfTo<UgfProjectInitializer>().AsSingle().NonLazy();

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
        }
    }
}
