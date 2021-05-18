namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public interface ISavegameSettings
    {
        string Filename { get; }
        bool UseCompression { get; }
    }
}
