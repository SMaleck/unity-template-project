namespace Source.Frameworks.ViewSystem
{
    public interface IClosableViewRegistrar
    {
        void Register<T>(IClosableViewController controller) where T : ClosableView;
    }
}
