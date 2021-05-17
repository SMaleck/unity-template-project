namespace Source.Frameworks.SavegameSystem.Runtime.Config
{
    public interface ISavegameConfig
    {
        string Filename { get; }
        double RequestSaveTimeoutSeconds { get; }
    }
}
