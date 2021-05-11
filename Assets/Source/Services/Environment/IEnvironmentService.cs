namespace Source.Services.Environment
{
    public interface IEnvironmentService
    {
        bool IsDebug { get; }
        bool IsAndroid { get; }
        bool IsIos { get; }
        int TargetFrameRate { get; }
    }
}