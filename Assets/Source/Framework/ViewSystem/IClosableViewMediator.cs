namespace Source.Framework.ViewSystem
{
    public interface IClosableViewMediator
    {
        void Open<T>() where T : ClosableView;
        void Close<T>() where T : ClosableView;
    }
}
