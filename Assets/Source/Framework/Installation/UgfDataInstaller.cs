using Source.Framework.Services.Audio.Config;
using Source.Framework.Services.Savegames.Config;
using Source.Framework.Services.SceneManagement.Config;
using UnityEngine;
using Zenject;

namespace Source.Framework.Installation
{
    [CreateAssetMenu(fileName = nameof(UgfDataInstaller), menuName = Constants.InstallersMenu + nameof(UgfDataInstaller))]
    public class UgfDataInstaller : ScriptableObjectInstaller<UgfDataInstaller>
    {
        [SerializeField] private SceneManagementConfig _sceneManagementConfig;
        [SerializeField] private SavegamesConfig _savegamesConfig;
        [SerializeField] private AudioServiceConfig _audioServiceConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_sceneManagementConfig);
            Container.BindInstance(_savegamesConfig);
            Container.BindInstance(_audioServiceConfig);
        }
    }
}