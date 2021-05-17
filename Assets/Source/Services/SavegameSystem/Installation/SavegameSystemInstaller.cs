using Source.Frameworks.SavegameSystem.Runtime.Config;
using Source.Frameworks.SavegameSystem.Runtime.Logging;
using Source.Frameworks.SavegameSystem.Runtime.Serializable;
using Source.Frameworks.SavegameSystem.Runtime.Storage;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Dal;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.PreWrite;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Read;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Middlewares.Write;
using Source.Frameworks.SavegameSystem.Runtime.Storage.Processors;
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
            Container.BindInterfacesTo<SerializationSettingsProvider>().AsSingle();
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
            Container.BindInterfacesTo<SavegameContentFactory>().AsSingle();
            Container.BindInterfacesTo<SavegameService>().AsSingle();
        }
    }
}
