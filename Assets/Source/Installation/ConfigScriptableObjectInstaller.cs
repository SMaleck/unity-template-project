﻿using SavegameSystem.Settings;
using Source.Frameworks;
using Source.Services.Audio.Config;
using Source.Services.SceneManagement.Config;
using UnityEngine;
using Zenject;

namespace Source.Installation
{
    [CreateAssetMenu(fileName = nameof(ConfigScriptableObjectInstaller), menuName = Constants.InstallersMenu + nameof(ConfigScriptableObjectInstaller))]
    public class ConfigScriptableObjectInstaller : ScriptableObjectInstaller<ConfigScriptableObjectInstaller>
    {
        [SerializeField] private SceneManagementConfig _sceneManagementConfig;
        [SerializeField] private AudioServiceConfig _audioServiceConfig;
        [SerializeField] private AudioClipsConfig _audioClipsConfig;

        [Header("Package Settings")]
        [SerializeField] private SavegameSettings _savegameSettings;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<SceneManagementConfig>().FromInstance(_sceneManagementConfig);
            Container.BindInterfacesAndSelfTo<AudioServiceConfig>().FromInstance(_audioServiceConfig);
            Container.BindInterfacesTo<AudioClipsConfig>().FromInstance(_audioClipsConfig);
            Container.BindInterfacesAndSelfTo<SavegameSettings>().FromInstance(_savegameSettings);
        }
    }
}