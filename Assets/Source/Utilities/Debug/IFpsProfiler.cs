namespace Source.Utilities.Debug
{
    public interface IFpsProfiler
    {
        int CurrentFps { get; }
        int MinFps { get; }
        int MaxFps { get; }
        int AverageFps { get; }
    }
}
