using System;
using Source.Utilities.Reactive;
using UniRx;

namespace Source.Services.SavegameSystem.Persistence
{
    public class AbstractSavegamePersistence : AbstractInjectableDisposable, ISavegamePersistence
    {
        protected static ReactiveProperty<T> CreateBoundProperty<T>(
            T initialValue,
            Action<T> setter,
            CompositeDisposable disposer)
        {
            var rxProperty = new ReactiveProperty<T>(initialValue).AddTo(disposer);
            rxProperty.Subscribe(setter).AddTo(disposer);

            return rxProperty;
        }
    }
}
