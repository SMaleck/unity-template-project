using Source.Frameworks.ViewSystem.Installation;

namespace Source.Installation.SceneInstallers
{
    public class GameSceneInstaller : AbstractSceneInstaller
    {
        protected override void InstallSceneBindings()
        {
            ViewSystemInstaller.Install(Container);
        }
    }
}
