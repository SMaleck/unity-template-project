using Source.Utilities.Mono;
using Zenject;

namespace Source.Frameworks.Views
{
    public abstract class AbstractView : AbstractDisposableMonoBehaviour, IInitializable
    {
        public bool IsActive => gameObject.activeSelf;

        public void Initialize()
        {
            OnInitialize();
        }

        public virtual void OnInitialize() { }

        public void SetActive(bool isActive)
        {
            this.gameObject.SetActive(isActive);
        }
    }
}
