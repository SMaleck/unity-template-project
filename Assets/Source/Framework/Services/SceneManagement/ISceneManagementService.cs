using UniRx;

namespace Source.Framework.Services.SceneManagement
{
    public interface ISceneManagementService
    {
        IOptimizedObservable<Unit> OnSceneLoadStarted { get; }

        void ToScene(string sceneName);
    }
}