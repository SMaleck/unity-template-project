using Source.Frameworks.Logging;
using Source.Frameworks.SavegameSystem.Storage;
using Source.Frameworks.SavegameSystem.Storage.Dal;
using Source.Frameworks.SavegameSystem.Storage.Middlewares.PreWrite;
using Source.Frameworks.SavegameSystem.Storage.Middlewares.Read;
using Source.Frameworks.SavegameSystem.Storage.Middlewares.Write;
using Source.Frameworks.SavegameSystem.Storage.Processors;
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
