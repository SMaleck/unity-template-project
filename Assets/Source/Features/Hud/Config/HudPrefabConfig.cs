using Source.Framework;
using UnityEngine;

namespace Source.Features.Hud.Config
{
    [CreateAssetMenu(fileName = nameof(HudPrefabConfig), menuName = Constants.ConfigMenu + nameof(HudPrefabConfig))]
    public class HudPrefabConfig : ScriptableObject
    {
        [SerializeField] private HudView _hudViewPrefab;
        public HudView HudViewPrefab => _hudViewPrefab;
    }
}
