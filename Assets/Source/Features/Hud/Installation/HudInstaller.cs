using Source.Frameworks;
using UnityEngine;
using Zenject;

namespace Source.Features.Hud.Installation
{
    [CreateAssetMenu(fileName = nameof(HudInstaller), menuName = Constants.InstallersMenu + nameof(HudInstaller))]
    public class HudInstaller : ScriptableObjectInstaller<HudInstaller>
    {
        [SerializeField] private HudView _hudViewPrefab;

        public override void InstallBindings()
        {
            Container.Bind<HudView>().FromComponentInNewPrefab(_hudViewPrefab)
                .AsSingle();

            Container.BindInterfacesTo<HudController>().AsSingle().NonLazy();
        }
    }
}
