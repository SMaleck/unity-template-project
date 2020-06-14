using Source.Framework.Util;
using Zenject;

namespace Source.Features.TitleScreen.Installation
{
    public class TitleScreenInstaller : Installer<TitleScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindPrefabFactory<TitleScreenView, TitleScreenView.Factory>();
        }
    }
}
