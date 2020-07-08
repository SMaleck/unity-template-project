using Source.Framework.Util.DataStorageStrategies;
using Source.Services.Savegames;
using Zenject;

namespace Source.Installation
{
    public class SavegameInstaller : Installer<SavegameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<JsonDataStorageStrategy>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegameService>().AsSingle();
            Container.BindInterfacesAndSelfTo<SavegamePersistenceScheduler>().AsSingle();
        }
    }
}
