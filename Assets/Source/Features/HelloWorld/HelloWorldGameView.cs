using UGF.Views;
using Zenject;

namespace Source.Features.HelloWorld
{
    public class HelloWorldGameView : AbstractView
    {
        public class Factory : PlaceholderFactory<UnityEngine.Object, HelloWorldGameView> { }
    }
}
