using Source.Framework.Services.Localization;
using Source.Framework.Services.Localization.Data;
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
