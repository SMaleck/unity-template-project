using Packages.RxUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UtilitiesGeneral.Logging;

namespace Source.Framework.ViewSystem
{
    public class ClosableViewMediator : AbstractDisposable, IClosableViewRegistrar, IClosableViewMediator
    {
        private readonly ILogger _logger;
        private readonly Dictionary<Type, IClosableViewController> _registeredViews;

        private readonly IReactiveProperty<bool> _isAnyPanelOpen;
        public IReadOnlyReactiveProperty<bool> IsAnyPanelOpen => _isAnyPanelOpen;

        public ClosableViewMediator(ILogger logger)
        {
            _logger = logger;
            _registeredViews = new Dictionary<Type, IClosableViewController>();

            _isAnyPanelOpen = new ReactiveProperty<bool>().AddTo(Disposer);
        }

        void IClosableViewRegistrar.Register<T>(IClosableViewController controller)
        {
            _registeredViews.Add(typeof(T), controller);

            controller.IsOpen
                .Subscribe(_ => UpdateIsAnyOpen())
                .AddTo(Disposer);
        }

        void IClosableViewMediator.Open<T>()
        {
            GetView<T>()?.Open();
        }

        void IClosableViewMediator.Close<T>()
        {
            GetView<T>()?.Close();
        }

        private IClosableViewController GetView<T>()
        {
            if (!_registeredViews.TryGetValue(typeof(T), out var controller))
            {
                _logger.Error($"No controller registered for {typeof(T).Name}");
            }

            return controller;
        }

        private void UpdateIsAnyOpen()
        {
            _isAnyPanelOpen.Value = _registeredViews.Values
                .Any(e => e.IsOpen.Value);
        }
    }
}
