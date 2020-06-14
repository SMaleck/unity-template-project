using Source.Features.TitleScreen.Config;
using Source.Framework;
using UnityEngine;
using Zenject;

namespace Source.Features.TitleScreen.Installation
{
    [CreateAssetMenu(fileName = nameof(TitleScreenSoInstaller), menuName = Constants.InstallersMenu + nameof(TitleScreenSoInstaller))]
    public class TitleScreenSoInstaller : ScriptableObjectInstaller<TitleScreenSoInstaller>
    {
        [SerializeField] private TitleScreenPrefabConfig _titleScreenPrefabConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_titleScreenPrefabConfig);
        }
    }
}
