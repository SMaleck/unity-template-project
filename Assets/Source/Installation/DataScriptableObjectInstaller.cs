using Source.Framework;
using Source.Framework.Services.Audio.Config;
using Source.Framework.Services.Savegames.Config;
using Source.Framework.Services.SceneManagement.Config;
using Source.Installation.Config;
using Source.Services.AudioPlayer.Config;
using UnityEngine;
using Zenject;

namespace Source.Installation
{
    [CreateAssetMenu(fileName = nameof(DataScriptableObjectInstaller), menuName = Constants.InstallersMenu + nameof(DataScriptableObjectInstaller))]
    public class DataScriptableObjectInstaller : ScriptableObjectInstaller<DataScriptableObjectInstaller>
    {
        [SerializeField] private SceneManagementConfig _sceneManagementConfig;
        [SerializeField] private SavegamesConfig _savegamesConfig;
        [SerializeField] private AudioServiceConfig _audioServiceConfig;
        [SerializeField] private ViewPrefabConfig _viewPrefabConfig;
        [SerializeField] private AudioClipsConfig _audioClipsConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_sceneManagementConfig);
            Container.BindInstance(_savegamesConfig);
            Container.BindInstance(_audioServiceConfig);
            Container.BindInstance(_viewPrefabConfig);
            Container.BindInstance(_audioClipsConfig);
        }
    }
}