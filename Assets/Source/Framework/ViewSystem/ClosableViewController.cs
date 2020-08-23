using Source.Framework.Util.UniRx;
using UniRx;
using Zenject;

namespace Source.Framework.ViewSystem
{
    public abstract class ClosableViewController<T> : AbstractDisposable, IInitializable, IClosableViewController where T : ClosableView
    {
        private readonly T _view;

        protected ClosableViewController(T view)
        {
            _view = view;
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
            _view.SetIsVisible(true);
            OnOpen();
        }

        public void Close()
        {
            _view.SetIsVisible(false);
            OnClose();
        }

        protected virtual void OnOpen() { }
        protected virtual void OnClose() { }
    }
}
