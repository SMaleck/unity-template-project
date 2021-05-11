﻿using UniRx;

namespace Source.Framework.ViewSystem
{
    public interface IClosableViewMediator
    {
        IReadOnlyReactiveProperty<bool> IsAnyPanelOpen { get; }

        void Open<T>() where T : ClosableView;
        void Close<T>() where T : ClosableView;
    }
}
