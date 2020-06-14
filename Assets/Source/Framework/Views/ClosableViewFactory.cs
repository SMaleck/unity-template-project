using Source.Framework.Views.Mediation;
using System.Linq;
using Zenject;

namespace Source.Framework.Views
{
    public class ClosableViewFactory
    {
        private readonly IClosableViewRegistrar _closableViewRegistrar;
        private readonly ClosableViewController.Factory _closableViewControllerFactory;

        public ClosableViewFactory(
            IClosableViewRegistrar closableViewRegistrar,
            ClosableViewController.Factory closableViewControllerFactory)
        {
            _closableViewRegistrar = closableViewRegistrar;
            _closableViewControllerFactory = closableViewControllerFactory;
        }

        public void SetupView<T>(T view) where T : AbstractView
        {
            var listOfInits = view.GetComponents<IInitializable>()
                .Where(viewItem => viewItem.GetType() != typeof(T))
                .ToList();

            listOfInits.ForEach(component => component.Initialize());

            view.GetComponentsInChildren<IInitializable>()
                .ToList()
                .ForEach(component => component.Initialize());
        }

        public void SetupClosableView(AbstractView abstractView)
        {
            SetupView(abstractView);

            var closableView = abstractView.GetComponent<IClosableView>();
            var closableViewController = _closableViewControllerFactory.Create(closableView);
        }

        public void SetupClosableView<T>(T abstractView, ClosableViewType closableViewType) where T : AbstractView
        {
            SetupView(abstractView);

            var closableView = abstractView.GetComponent<IClosableView>();
            var closableViewController = _closableViewControllerFactory.Create(closableView);

            _closableViewRegistrar.RegisterClosableView(closableViewType, closableViewController);
        }
    }
}
