using SavegameSystem.Storage.ResourceProviders;
using UnityEngine;

namespace Source.Services.Environment
{
    public class EnvironmentService : IEnvironmentService, ISavegameEnvironmentProvider
    {
        public static bool IsDebugStatic => UnityEngine.Debug.isDebugBuild;

        public bool IsDebug => IsDebugStatic;
        public bool IsStandalone { get; }
        public bool IsAndroid { get; }
        public bool IsIos { get; }

        public int TargetFrameRate => 60;

        public EnvironmentService()
        {
#if UNITY_STANDALONE || UNITY_STANDALONE_WIN
            IsStandalone = true;
#elif UNITY_ANDROID
            IsAndroid = true;
#elif UNITY_IOS
            IsIos = true;
#endif

            Application.targetFrameRate = TargetFrameRate;
        }
    }
}
