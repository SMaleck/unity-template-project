using Source.Features.Hud.Config;
using Source.Framework;
using UnityEngine;
using Zenject;

namespace Source.Features.Hud.Installation
{
    [CreateAssetMenu(fileName = nameof(HudInstaller), menuName = Constants.InstallersMenu + nameof(HudInstaller))]
    public class HudInstaller : ScriptableObjectInstaller<HudInstaller>
    {
        [SerializeField] private HudPrefabConfig _hudPrefabConfig;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<HudController>().AsSingle().NonLazy();

            Container.BindInstance(_hudPrefabConfig);
            Container.Bind<HudView>().FromInstance(_hudPrefabConfig.HudViewPrefab);
        }
    }
}
