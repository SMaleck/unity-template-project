﻿using System;
using UniRx;

namespace Source.Utilities.Reactive
{
    public abstract class AbstractDisposable : IDisposable
    {
        protected CompositeDisposable Disposer = new CompositeDisposable();
        
        public void Dispose(CompositeDisposable disposer)
        {
            if (disposer == null)
            {
                return;
            }

            OnDispose();
            disposer.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Dispose()
        {
            Dispose(Disposer);
        }

        protected virtual void OnDispose() { }
    }
}
