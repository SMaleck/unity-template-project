using Source.Features.HelloWorld;
using Source.Features.HelloWorld.Config;
using Source.Features.Hud.Config;
using Source.Framework.Views.Mediation;
using Zenject;

namespace Source.Initialization
{
    public class GameSceneInitializer : AbstractSceneInitializer
    {
        [Inject] private readonly HelloWorldPrefabConfig _helloWorldPrefabConfig;
        [Inject] private readonly HudPrefabConfig _hudPrefabConfig;

        [Inject] private readonly HelloWorldGameView.Factory _helloWorldGameViewFactory;

        public override void Initialize()
        {
            ClosableViewFactory.SetupView(_hudPrefabConfig.HudViewPrefab);

            var helloWorldGameView = _helloWorldGameViewFactory.Create(_helloWorldPrefabConfig.HelloWorldGameViewPrefab);
            ClosableViewFactory.SetupClosableView(helloWorldGameView, ClosableViewType.HelloWorld);
        }
    }
}
