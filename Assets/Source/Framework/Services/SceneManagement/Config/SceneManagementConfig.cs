using Source.Framework.Services.SceneManagement.LoadingScreen;
using UnityEngine;

namespace Source.Framework.Services.SceneManagement.Config
{
    [CreateAssetMenu(fileName = nameof(SceneManagementConfig), menuName = Constants.MenuRoot + nameof(SceneManagementConfig))]
    public class SceneManagementConfig : ScriptableObject
    {
        [Header("Prefabs")]
        [SerializeField] private LoadingScreenView _loadingScreenViewPrefab;
        public LoadingScreenView LoadingScreenViewPrefab => _loadingScreenViewPrefab;

    }
}