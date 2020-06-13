using Source.Framework;
using Source.Framework.Util;
using UnityEngine;
using Zenject;

namespace Source.Features.TitleScreen.Installation
{
    [CreateAssetMenu(fileName = nameof(TitleScreenPrefabInstaller ), menuName = Constants.InstallersMenu + nameof(TitleScreenPrefabInstaller ))]
    public class TitleScreenPrefabInstaller : ScriptableObjectInstaller<TitleScreenPrefabInstaller >
    {
        [SerializeField] private HelloWorldTitleView _helloWorldTitleView;

        public override void InstallBindings()
        {
            //Container.BindInstance(_helloWorldTitleView);

            Container.BindPrefabFactory<HelloWorldTitleView, HelloWorldTitleView.Factory>();
        }
    }
}
