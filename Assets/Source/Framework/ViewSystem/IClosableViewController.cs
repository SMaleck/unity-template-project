using UniRx;

namespace Source.Framework.ViewSystem
{
    public interface IClosableViewController
    {
        IReadOnlyReactiveProperty<bool> IsOpen { get; }

        void Open();
        void Close();
    }
}
