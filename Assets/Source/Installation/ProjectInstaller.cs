using Source.Initialization;
using UtilitiesGeneral.Logging;
using Zenject;

namespace Source.Installation
{
    public class ProjectInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindExecutionOrder<ProjectInitializer>(998);
            Container.BindInterfacesAndSelfTo<ProjectInitializer>().AsSingle().NonLazy();

            Container.BindInterfacesTo<InstanceLogger>().AsSingle();

            ServiceInstaller.Install(Container);
        }
    }
}
