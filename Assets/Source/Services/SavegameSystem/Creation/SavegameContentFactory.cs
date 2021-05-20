using SavegameSystem.Serializable.Creation;
using Source.Services.SavegameSystem.Serializable;

namespace Source.Services.SavegameSystem.Creation
{
    public class SavegameContentFactory : ISavegameContentFactory
    {
        public T Create<T>() where T: class
        {
            return new SavegameContent()
            {
            } as T;
        }
    }
}
