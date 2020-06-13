using Source.Features.HelloWorld;
using Source.Features.TitleScreen;
using Source.Framework.Initialization;
using Source.Installation.Config;
using Zenject;

namespace Source.Initialization
{
    public class TitleSceneInitializer : AbstractSceneInitializer
    {
        [Inject] private readonly ViewPrefabConfig _viewPrefabConfig;
        [Inject] private readonly HelloWorldTitleView.Factory _helloWorldTitleViewFactory;

        public override void Initialize()
        {
            var helloWorldTitleView = _helloWorldTitleViewFactory.Create(_viewPrefabConfig.HelloWorldTitleViewPrefab);
            SetupView(helloWorldTitleView);
        }
    }
}
