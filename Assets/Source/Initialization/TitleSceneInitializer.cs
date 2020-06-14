using Source.Features.TitleScreen;
using Source.Features.TitleScreen.Config;
using Source.Framework.Initialization;
using Zenject;

namespace Source.Initialization
{
    public class TitleSceneInitializer : AbstractSceneInitializer
    {
        [Inject] private readonly TitleScreenPrefabConfig _titleScreenPrefabConfig;
        [Inject] private readonly TitleScreenView.Factory _helloWorldTitleViewFactory;

        public override void Initialize()
        {
            var helloWorldTitleView = _helloWorldTitleViewFactory.Create(_titleScreenPrefabConfig.TitleScreenViewPrefab);
            SetupView(helloWorldTitleView);
        }
    }
}
