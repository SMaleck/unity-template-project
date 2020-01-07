using UGF.Initialization;
using UGF.Services.Audio;
using UGF.Services.Particles;
using UGF.Services.Savegames;
using UGF.Services.SceneManagement;
using UGF.Services.SceneManagement.LoadingScreen;
using UGF.Util;
using UGF.Util.DataStorageStrategies;
using Zenject;

namespace UGF.Installation
{
    public class UgfProjectInstaller : MonoInstaller
    {
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

            Container.BindPrefabFactory<ParticlePoolItem, ParticlePoolItem.Factory>();
            Container.BindInterfacesAndSelfTo<ParticleService>().AsSingle().NonLazy();

            Container.BindPrefabFactory<AudioPoolItem, AudioPoolItem.Factory>();
            Container.BindInterfacesAndSelfTo<AudioService>().AsSingle().NonLazy();
        }
    }
}
