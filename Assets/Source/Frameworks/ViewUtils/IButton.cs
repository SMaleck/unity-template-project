using System;
using UniRx;

namespace Source.Frameworks.ViewUtils
{
    public interface IButton
    {
        IObservable<Unit> OnButtonClicked { get; }
        IObservable<Unit> OnInactiveButtonClicked { get; }
        IReadOnlyReactiveProperty<bool> IsInteractable { get; }
    }
}
