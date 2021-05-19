namespace SavegameSystem.Settings
{
    public interface ISavegameSettings
    {
        string Filename { get; }
        bool UseCompression { get; }
    }
}
