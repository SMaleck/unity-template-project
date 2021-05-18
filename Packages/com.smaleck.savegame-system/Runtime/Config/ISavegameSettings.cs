namespace SavegameSystem.Config
{
    public interface ISavegameSettings
    {
        string Filename { get; }
        bool UseCompression { get; }
    }
}
