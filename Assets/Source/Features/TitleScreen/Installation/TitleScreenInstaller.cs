using Source.Framework;
using UnityEngine;
using Zenject;

namespace Source.Features.TitleScreen.Installation
{
    [CreateAssetMenu(fileName = nameof(TitleScreenInstaller), menuName = Constants.InstallersMenu + nameof(TitleScreenInstaller))]
    public class TitleScreenInstaller : ScriptableObjectInstaller<TitleScreenInstaller>
    {
        [SerializeField] private TitleScreenView _titleScreenViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<TitleScreenView>().FromComponentInNewPrefab(_titleScreenViewPrefab)
                .AsSingle()
                .NonLazy();

            Container.BindInterfacesTo<TitleScreenController>().AsSingle().NonLazy();
        }
    }
}
