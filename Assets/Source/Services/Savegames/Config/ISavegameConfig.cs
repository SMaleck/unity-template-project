namespace Source.Services.Savegames.Config
{
    public interface ISavegameConfig
    {
        string Filename { get; }
        double RequestSaveTimeoutSeconds { get; }
    }
}
