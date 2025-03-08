public enum StopwatchState
{
    Ready,
    Running,
    Paused
}

public class SplitSecondStopwatch(TimeProvider time)
{
    private readonly List<TimeSpan> _previousLapSegments = new();
    private DateTimeOffset? _currentSegmentStart;
    
    public StopwatchState State { get; private set; }

    public List<TimeSpan> PreviousLaps { get; } = new();
    
    public TimeSpan CurrentLap => PreviousLapSegments + CurrentSegment;

    private TimeSpan PreviousLapSegments => _previousLapSegments.Aggregate(TimeSpan.Zero, (total, segment) => total + segment);

    private TimeSpan CurrentSegment => _currentSegmentStart is {} start ? time.GetUtcNow() - start : TimeSpan.Zero;

    public void Start()
    {
        if (State == StopwatchState.Paused)
            _currentSegmentStart = null;
        
        _currentSegmentStart ??= time.GetUtcNow();
        
        State = StopwatchState.Running;
    }

    public void Stop()
    {
        if (State == StopwatchState.Ready)
            return;
        
        PreviousLaps.Add(CurrentLap);
        _currentSegmentStart = null;
        State = StopwatchState.Stopped;
    }

    public void Split()
    {
        AddSegment();
    }

    public void Pause()
    {
        State = StopwatchState.Paused;
        AddSegment();
    }

    public void Reset()
    {
        Stop();
        _previousLapSegments.Clear();
        Start();
    }

    private void AddSegment()
    {
        _previousLapSegments.Add(CurrentSegment);
        _currentSegmentStart = null;
    }
}
