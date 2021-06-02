using SavegameSystem.Logging;
using SavegameSystem.Serializable.Creation;
using SavegameSystem.Settings;
using SavegameSystem.Storage;
using SavegameSystem.Storage.Middlewares.PreWrite;
using SavegameSystem.Storage.Middlewares.Read;
using SavegameSystem.Storage.Middlewares.Write;
using SavegameSystem.Storage.Migration;
using SavegameSystem.Storage.ResourceProviders;
using SavegameSystem.Storage.Serialization;
using SavegameSystem.Storage.Strategies;
using Source.Services.SavegameSystem.Creation;
using Zenject;

namespace Source.Services.SavegameSystem.Installation
{
    public class SavegameSystemInstaller : Installer<SavegameSystemInstaller>
    {
        public override void InstallBindings()
        {
            // ------------------------------- PACKAGE Bindings
            Container.BindInterfacesTo<DefaultSavegameLogger>().AsSingle();
            Container.BindInterfacesTo<SerializationSettings>().AsSingle();
            Container.BindInterfacesTo<JsonConvertersProvider>().AsSingle();
            Container.BindInterfacesTo<SavegameStorage>().AsSingle();
            Container.BindInterfacesTo<DefaultLocalSavegameStorageStrategy>().AsSingle();
            Container.BindInterfacesTo<SavegameAccessLockProvider>().AsSingle();

            // --------------- PACKAGE Resources
            Container.BindInterfacesTo<DefaultSavegameIdProvider>().AsSingle();
            Container.BindInterfacesTo<DefaultSavegamePathProvider>().AsSingle();
            Container.BindInterfacesTo<DefaultSavegameEnvironmentProvider>().AsSingle();

            // --------------- PACKAGE Creation
            Container.BindInterfacesTo<SavegameFactory>().AsSingle();
            Container.BindInterfacesTo<SavegameMetaDataFactory>().AsSingle();

            // --------------- PACKAGE Processors
            Container.BindInterfacesTo<MigrationProcessor>().AsSingle().NonLazy();
            Container.BindInterfacesTo<MigrationDebugger>().AsSingle();
            Container.BindInterfacesTo<SerializationProcessor>().AsSingle().NonLazy();

            // --------------- PACKAGE Middlewares
            Container.BindInterfacesTo<DecompressorMiddleware>().AsSingle().NonLazy();
            Container.BindInterfacesTo<CompressorMiddleware>().AsSingle().NonLazy();
            Container.BindInterfacesTo<UpdateVersionMiddleware>().AsSingle().NonLazy();
            Container.BindInterfacesTo<UpdateTimestampMiddleware>().AsSingle().NonLazy();

            // ------------------------------- CLIENT Bindings
            Container.BindInterfacesTo<SavegameContentFactory>().AsSingle();
            Container.BindInterfacesTo<SavegameResourcesProvider>().AsSingle();
            Container.BindInterfacesTo<SavegameService>().AsSingle();
        }
    }
}
