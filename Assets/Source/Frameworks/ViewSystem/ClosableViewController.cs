using Source.Utilities.Reactive;
using UniRx;
using Zenject;

namespace Source.Frameworks.ViewSystem
{
    public abstract class ClosableViewController<T> : AbstractDisposable, IInitializable, IClosableViewController where T : ClosableView
    {
        private readonly T _view;

        private readonly IReactiveProperty<bool> _isOpen;
        public IReadOnlyReactiveProperty<bool> IsOpen => _isOpen;

        protected ClosableViewController(T view)
        {
            _view = view;

            _isOpen = new ReactiveProperty<bool>().AddTo(Disposer);

            _isOpen
                .Subscribe(_view.SetIsVisible)
                .AddTo(Disposer);
        }

        [Inject]
        private void Inject(IClosableViewRegistrar closableViewRegistrar)
        {
            closableViewRegistrar.Register<T>(this);
        }

        public void Initialize()
        {
            _view.CloseButton.OnButtonClicked
                .Subscribe(_ => Close())
                .AddTo(Disposer);

            OnInitialize();
            Close();
        }

        protected virtual void OnInitialize() { }

        public void Open()
        {
            _isOpen.Value = true;
            OnOpen();
        }

        public void Close()
        {
            _isOpen.Value = false;
            OnClose();
        }

        protected virtual void OnOpen() { }
        protected virtual void OnClose() { }
    }
}
