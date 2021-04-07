using System;
using Source.Framework.Util.UniRx;
using Source.Packages.SavegameSystem.Models;
using UniRx;

namespace Source.Services.Savegames.Models
{
    [Serializable]
    public class AbstractSavegameData : ISavegameData
    {
    }

    public class AbstractSavegame : AbstractDisposable, ISavegame
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
