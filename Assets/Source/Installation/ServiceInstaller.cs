using Source.ServicesStatic.Localization;
using Source.ServicesStatic.Localization.Data;
using Zenject;

namespace Source.Installation
{
    public class ServiceInstaller : Installer<ServiceInstaller>
    {
        public override void InstallBindings()
        {
            TextService.Initialize(new TextDataSource());
        }
    }
}
