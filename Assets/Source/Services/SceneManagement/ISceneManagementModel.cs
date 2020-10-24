using System;
using UniRx;

namespace Source.Services.SceneManagement
{
    public interface ISceneManagementModel
    {
        IObservable<Unit> OnSceneStarted { get; }
    }
}
