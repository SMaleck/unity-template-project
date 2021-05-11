using Zenject;

namespace Source.Frameworks.ViewSystem.Installation
{
    public class ViewSystemInstaller : Installer<ViewSystemInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ClosableViewMediator>().AsSingle().NonLazy();
        }
    }
}
