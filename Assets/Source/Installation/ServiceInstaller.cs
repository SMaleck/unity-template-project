using Source.Services.Audio;
using Source.Services.Audio.Config;
using Source.Services.Random;
using Source.Services.SavegameSystem.Installation;
using Source.Services.Time;
using Source.ServicesStatic.Localization;
using Source.ServicesStatic.Localization.Data;
using Zenject;

namespace Source.Installation
{
    public class ServiceInstaller : Installer<ServiceInstaller>
    {
        [Inject] private AudioServiceConfig _audioServiceConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesTo<TimeService>().AsSingle().NonLazy();
            Container.BindInterfacesTo<RandomNumberService>().AsSingle().NonLazy();

            Container.BindInterfacesTo<AudioService>().AsSingle().NonLazy();
            Container.BindMemoryPool<AudioSourceItem, AudioSourceItem.Pool>()
                .FromComponentInNewPrefab(_audioServiceConfig.AudioSourcePrefab)
                .UnderTransformGroup("Audio");

            TextService.Initialize(new TextDataSource());

            SavegameSystemInstaller.Install(Container);
        }
    }
}
