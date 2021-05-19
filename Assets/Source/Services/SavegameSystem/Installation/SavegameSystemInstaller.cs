using SavegameSystem.Logging;
using SavegameSystem.Serializable;
using SavegameSystem.Settings;
using SavegameSystem.Storage;
using SavegameSystem.Storage.Dal;
using SavegameSystem.Storage.Middlewares.PreWrite;
using SavegameSystem.Storage.Middlewares.Read;
using SavegameSystem.Storage.Middlewares.Write;
using SavegameSystem.Storage.Migration;
using SavegameSystem.Storage.Serialization;
using Source.Services.SavegameSystem.Creation;
using Zenject;

namespace Source.Services.SavegameSystem.Installation
{
    public class SavegameSystemInstaller : Installer<SavegameSystemInstaller>
    {
        public override void InstallBindings()
        {
            // ------------------------------- PACKAGE Bindings
            Container.BindInterfacesTo<SavegameStorage>().AsSingle();
            Container.BindInterfacesTo<DefaultLocalSavegameDal>().AsSingle();
            Container.BindInterfacesTo<DefaultSavegameLogger>().AsSingle();
            Container.BindInterfacesTo<SerializationSettings>().AsSingle();
            Container.BindInterfacesTo<JsonConvertersProvider>().AsSingle();

            // --------------- PACKAGE Processors
            Container.BindInterfacesTo<MigrationProcessor>().AsSingle().NonLazy();
            Container.BindInterfacesTo<SerializationProcessor>().AsSingle().NonLazy();

            // --------------- PACKAGE Middlewares
            Container.BindInterfacesTo<DecompressorMiddleware>().AsSingle().NonLazy();
            Container.BindInterfacesTo<CompressorMiddleware>().AsSingle().NonLazy();
            Container.BindInterfacesTo<UpdateTimestampMiddleware>().AsSingle().NonLazy();

            // ------------------------------- CLIENT Bindings
            Container.BindInterfacesTo<SavegameFactory>().AsSingle();
            Container.BindInterfacesTo<SavegameMetaDataFactory>().AsSingle();
            Container.BindInterfacesTo<SavegameContentFactory>().AsSingle();

            Container.BindInterfacesTo<SavegameService>().AsSingle();
        }
    }
}
