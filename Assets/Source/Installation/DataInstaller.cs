using Source.Installation.Config;
using Source.Services.AudioPlayer.Config;
using UGF.Installation;
using UnityEngine;
using Zenject;

namespace Source.Installation
{
    [CreateAssetMenu(fileName = nameof(DataInstaller), menuName = Constants.UMenuInstallers + nameof(DataInstaller))]
    public class DataInstaller : ScriptableObjectInstaller<UgfDataInstaller>
    {
        [SerializeField] private ViewPrefabConfig _viewPrefabConfig;
        [SerializeField] private AudioClipsConfig _audioClipsConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_viewPrefabConfig);
            Container.BindInstance(_audioClipsConfig);
        }
    }
}