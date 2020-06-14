using Source.Features.HelloWorld;
using Source.Features.HelloWorld.Config;
using Source.Framework.Initialization;
using Source.Framework.Views.Mediation;
using Zenject;

namespace Source.Initialization
{
    public class GameSceneInitializer : AbstractSceneInitializer
    {
        [Inject] private readonly HelloWorldPrefabConfig _helloWorldPrefabConfig;
        [Inject] private readonly HelloWorldHudView.Factory _helloWorldHudViewFactory;
        [Inject] private readonly HelloWorldGameView.Factory _helloWorldGameViewFactory;

        public override void Initialize()
        {
            var helloWorldHudView = _helloWorldHudViewFactory.Create(_helloWorldPrefabConfig.HelloWorldHudViewPrefab);
            SetupView(helloWorldHudView);

            var helloWorldGameView = _helloWorldGameViewFactory.Create(_helloWorldPrefabConfig.HelloWorldGameViewPrefab);
            SetupClosableView(helloWorldGameView, ClosableViewType.HelloWorld);
        }
    }
}
