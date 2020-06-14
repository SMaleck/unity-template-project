using Source.Features.HelloWorld;
using Source.Framework.Util;
using Zenject;

namespace Source.Features.Hud.Installation
{
    public class HudInstaller : Installer<HudInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindPrefabFactory<HudView, HudView.Factory>();
        }
    }
}
