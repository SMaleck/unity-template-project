﻿using Packages.RxUtils;
using UniRx;

namespace Source.Services.SceneManagement
{
    public class SceneManagementModel : AbstractDisposable
    {
        private readonly Subject<Unit> _onSceneStarted;
        public IOptimizedObservable<Unit> OnSceneStarted => _onSceneStarted;

        public SceneManagementModel()
        {
            _onSceneStarted = new Subject<Unit>().AddTo(Disposer);
        }

        public void PublishOnSceneStarted()
        {
            _onSceneStarted.OnNext(Unit.Default);
        }
    }
}
