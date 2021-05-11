﻿using System;
using Source.Services.SceneManagement.LoadingScreen;
using Source.Utilities.Reactive;
using UniRx;
using UnityEngine.SceneManagement;

namespace Source.Services.SceneManagement
{
    public class SceneManagementService : AbstractDisposable, ISceneManagementService
    {
        private readonly SceneManagementModel _sceneManagementModel;
        private readonly LoadingScreenModel _loadingScreenModel;
        private readonly SerialDisposable _loadingScreenVisibilityDisposer;

        private readonly Subject<Unit> _onSceneLoadStarted;
        public IOptimizedObservable<Unit> OnSceneLoadStarted => _onSceneLoadStarted;

        public SceneManagementService(
            SceneManagementModel sceneManagementModel,
            LoadingScreenModel loadingScreenModel)
        {
            _sceneManagementModel = sceneManagementModel;
            _loadingScreenModel = loadingScreenModel;
            _loadingScreenVisibilityDisposer = new SerialDisposable().AddTo(Disposer);

            _onSceneLoadStarted = new Subject<Unit>().AddTo(Disposer);

            _loadingScreenModel.OnCloseLoadingScreenCompleted
                .Subscribe(_ => _sceneManagementModel.PublishOnSceneStarted())
                .AddTo(Disposer);
        }

        private void StartSceneLoad(string sceneName)
        {
            _loadingScreenModel.SetIsLoadingScreenVisible(true);
            _onSceneLoadStarted.OnNext(Unit.Default);

            //_loadingScreenVisibilityDisposer.Disposable = _loadingScreenModel.OnOpenLoadingScreenCompleted
            //    .Subscribe(_ => LoadScene(sceneName));
            LoadScene(sceneName);
        }

        private void LoadScene(string sceneName)
        {
            _loadingScreenVisibilityDisposer.Disposable?.Dispose();
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        private static IObservable<Unit> LoadScene(Scenes sceneIndex)
        {
            return SceneManager.LoadSceneAsync((int)sceneIndex, LoadSceneMode.Additive)
                .AsAsyncOperationObservable()
                .AsUnitObservable();
        }

        private static IObservable<Unit> UnloadScene(Scenes sceneIndex)
        {
            return SceneManager.UnloadSceneAsync((int)sceneIndex)
                .AsAsyncOperationObservable()
                .AsUnitObservable();
        }

        public void OnSceneInitializationCompleted()
        {
            _loadingScreenModel.SetIsLoadingScreenVisible(false);
        }

        public void Startup()
        {
            LoadScene(Scenes.SavegameScene)
                .ContinueWith(_ => UnloadScene(Scenes.InitScene))
                .Subscribe();
        }

        public void ToTitle()
        {
            LoadScene(Scenes.TitleScene)
                .Subscribe();
        }

        public void ToGame()
        {
            LoadScene(Scenes.GameScene)
                .ContinueWith(_ => UnloadScene(Scenes.TitleScene))
                .Subscribe();
        }
    }
}
