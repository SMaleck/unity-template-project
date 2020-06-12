using System;

namespace Source.Framework.Views.Closable.AnimationStrategies
{
    public interface IIClosableViewAnimationStrategy
    {
        void Open(Action onComplete);
        void Close(Action onComplete);
    }
}
