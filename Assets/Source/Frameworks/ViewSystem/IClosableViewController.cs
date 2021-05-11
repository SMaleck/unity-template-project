using UniRx;

namespace Source.Frameworks.ViewSystem
{
    public interface IClosableViewController
    {
        IReadOnlyReactiveProperty<bool> IsOpen { get; }

        void Open();
        void Close();
    }
}
