using Source.Framework.Logging;
using System;
using System.Collections.Generic;

namespace Source.Framework.ViewSystem
{
    public class ClosableViewMediator : IClosableViewRegistrar, IClosableViewMediator
    {
        private readonly ILogger _logger;
        private readonly Dictionary<Type, IClosableViewController> _registeredViews;

        public ClosableViewMediator(ILogger logger)
        {
            _logger = logger;
            _registeredViews = new Dictionary<Type, IClosableViewController>();
        }

        void IClosableViewRegistrar.Register<T>(IClosableViewController controller)
        {
            _registeredViews.Add(typeof(T), controller);
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
    }
}
