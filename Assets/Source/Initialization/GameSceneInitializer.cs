using Source.Features.HelloWorld;
using Source.Features.HelloWorld.Config;
using Source.Features.Hud;
using Source.Features.Hud.Config;
using Source.Framework.Views.Mediation;
using Zenject;

namespace Source.Initialization
{
    public class GameSceneInitializer : AbstractSceneInitializer
    {
        [Inject] private readonly HelloWorldPrefabConfig _helloWorldPrefabConfig;
        [Inject] private readonly HudPrefabConfig _hudPrefabConfig;

        [Inject] private readonly HudView.Factory _helloWorldHudViewFactory;
        [Inject] private readonly HelloWorldGameView.Factory _helloWorldGameViewFactory;

        public override void Initialize()
        {
            var helloWorldHudView = _helloWorldHudViewFactory.Create(_hudPrefabConfig.HudViewPrefab);
            ClosableViewFactory.SetupView(helloWorldHudView);

            var helloWorldGameView = _helloWorldGameViewFactory.Create(_helloWorldPrefabConfig.HelloWorldGameViewPrefab);
            ClosableViewFactory.SetupClosableView(helloWorldGameView, ClosableViewType.HelloWorld);
        }
    }
}
