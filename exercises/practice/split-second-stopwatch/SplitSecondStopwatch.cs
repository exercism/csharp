public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{    
    public StopwatchState State { get; }
    public TimeSpan CurrentLap { get; }
    public TimeSpan Total { get; }
    public IReadOnlyCollection<TimeSpan> PreviousLaps { get; }

    public void Start()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public void Stop()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public void Reset()
    {
        throw new NotImplementedException("You need to implement this method.");
    }

    public void Lap()
    {
        throw new NotImplementedException("You need to implement this method.");
    }
}
