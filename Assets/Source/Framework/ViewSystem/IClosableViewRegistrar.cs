namespace Source.Framework.ViewSystem
{
    public interface IClosableViewRegistrar
    {
        void Register<T>(IClosableViewController controller) where T : ClosableView;
    }
}
