namespace Source.Framework.Views.Mediation
{
    public interface IClosableViewRegistrar
    {
        void RegisterClosableView(ClosableViewType closableViewType, IClosableViewController closableViewController);
    }
}
