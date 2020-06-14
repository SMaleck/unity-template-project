﻿using Source.Framework;
using Source.Services.Audio.Config;
using Source.Services.AudioPlayer.Config;
using Source.Services.Savegames.Config;
using Source.Services.SceneManagement.Config;
using UnityEngine;
using Zenject;

namespace Source.Installation
{
    [CreateAssetMenu(fileName = nameof(ConfigScriptableObjectInstaller), menuName = Constants.InstallersMenu + nameof(ConfigScriptableObjectInstaller))]
    public class ConfigScriptableObjectInstaller : ScriptableObjectInstaller<ConfigScriptableObjectInstaller>
    {
        [SerializeField] private SceneManagementConfig _sceneManagementConfig;
        [SerializeField] private SavegamesConfig _savegamesConfig;
        [SerializeField] private AudioServiceConfig _audioServiceConfig;
        [SerializeField] private AudioClipsConfig _audioClipsConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_sceneManagementConfig);
            Container.BindInstance(_savegamesConfig);
            Container.BindInstance(_audioServiceConfig);
            Container.BindInstance(_audioClipsConfig);
        }
    }
}