using System;
using UniRx;

namespace Source.Framework.Services.SceneManagement
{
    public interface ISceneManagementModel
    {
        IObservable<Unit> OnSceneStarted { get; }
    }
}
