using Source.Features.Hud.Config;
using Source.Framework;
using UnityEngine;
using Zenject;

namespace Source.Features.Hud.Installation
{
    [CreateAssetMenu(fileName = nameof(HudSoInstaller), menuName = Constants.InstallersMenu + nameof(HudSoInstaller))]
    public class HudSoInstaller : ScriptableObjectInstaller<HudSoInstaller>
    {
        [SerializeField] private HudPrefabConfig _hudPrefabConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_hudPrefabConfig);
        }
    }
}
