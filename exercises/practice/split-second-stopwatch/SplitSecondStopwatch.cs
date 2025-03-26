public enum StopwatchState
{
    Ready,
    Running
}

public class SplitSecondStopwatch(TimeProvider time)
{
    private readonly List<TimeSpan> _splits = new();
    private DateTimeOffset? _splitStart;
    
    private TimeSpan PreviousSplits => _splits.Aggregate(TimeSpan.Zero, (total, split) => total + split);
    private TimeSpan CurrentSplit => _splitStart is {} start ? time.GetUtcNow() - start : TimeSpan.Zero;

    public StopwatchState State { get; private set; } = StopwatchState.Ready;
    public List<TimeSpan> PreviousLaps { get; } = new();

    public TimeSpan CurrentLap => CurrentSplit + PreviousSplits;
    public TimeSpan Total => CurrentLap + PreviousLaps.Aggregate(TimeSpan.Zero, (total, split) => total + split);

    public void Start()
    {
        if (State != StopwatchState.Ready)
            throw new InvalidOperationException("Can't start a stopwatch that is not stopped.");
        
        _splitStart = time.GetUtcNow();
        State = StopwatchState.Running;
    }

    public void Stop()
    {
        if (State != StopwatchState.Running)
            throw new InvalidOperationException("Can't stop a stopwatch that is not started.");

        _splits.Add(CurrentSplit);
        _splitStart = null;
        State = StopwatchState.Ready;
    }
    
    public void Reset()
    {
        if (State != StopwatchState.Ready)
            throw new InvalidOperationException("Can't reset a stopwatch that is not stopped.");
        
        _splits.Clear();
        _splitStart = null;
        State = StopwatchState.Ready;
    }
    
    public void Lap()
    {
        if (State != StopwatchState.Running)
            throw new InvalidOperationException("Can't lap a stopwatch that is not started stopped.");
        
        PreviousLaps.Add(CurrentLap);
        _splits.Clear();
        _splitStart = time.GetUtcNow();
    }
}
