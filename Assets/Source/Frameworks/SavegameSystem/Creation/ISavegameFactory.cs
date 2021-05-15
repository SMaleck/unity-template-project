using Source.Frameworks.SavegameSystem.Serializable;

namespace Source.Frameworks.SavegameSystem.Creation
{
    public interface ISavegameFactory<T>
    {
        ISavegame<T> Create();
    }
}
