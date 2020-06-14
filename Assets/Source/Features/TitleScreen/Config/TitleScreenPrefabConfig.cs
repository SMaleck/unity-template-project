using Source.Framework;
using UnityEngine;

namespace Source.Features.TitleScreen.Config
{
    [CreateAssetMenu(fileName = nameof(TitleScreenPrefabConfig), menuName = Constants.ConfigMenu + nameof(TitleScreenPrefabConfig))]
    public class TitleScreenPrefabConfig : ScriptableObject
    {
        [SerializeField] private TitleScreenView _titleScreenViewPrefab;
        public TitleScreenView TitleScreenViewPrefab => _titleScreenViewPrefab;
    }
}
