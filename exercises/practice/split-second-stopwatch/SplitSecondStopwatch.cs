public enum StopwatchState
{
    Ready,
    Running,
    Paused,
    Stopped
}

public class SplitSecondStopwatch
{
    public StopwatchState State { get; private set; }
}
