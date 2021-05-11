using UniRx;
using UnityEngine;
using Zenject;

namespace Source.Utilities.Mono
{
    public abstract class AbstractDisposableMonoBehaviour : MonoBehaviour
    {
        private CompositeDisposable _disposer;
        public CompositeDisposable Disposer => _disposer ??
            (_disposer = new CompositeDisposable().AddTo(this));

        [Inject]
        private void Inject([InjectOptional] CompositeDisposable disposer)
        {
            _disposer = disposer;
        }
    }
}
