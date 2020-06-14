using Source.Framework.Views;
using Zenject;

namespace Source.Initialization
{
    public abstract class AbstractSceneInitializer : ISceneInitializer
    {
        [Inject] protected readonly ClosableViewFactory ClosableViewFactory;

        public abstract void Initialize();
    }
}
