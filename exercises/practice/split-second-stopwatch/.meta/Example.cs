public enum StopwatchState
{
    Ready,
    Running,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{
    private List<TimeSpan> _previousLaps = [];
    private TimeSpan _currentLapTrackedTime = TimeSpan.Zero;
    private DateTimeOffset? _currentLapTrackingTimeSince; 

    private TimeSpan PreviousLapsTotal => _previousLaps.Aggregate(TimeSpan.Zero, (total, lap) => total + lap);
    private TimeSpan CurrentLapTrackingTime =>
        _currentLapTrackingTimeSince is null ? TimeSpan.Zero : time.GetUtcNow() - _currentLapTrackingTimeSince.Value;
    
    public StopwatchState State { get; private set; } = StopwatchState.Ready;
    public TimeSpan CurrentLap => _currentLapTrackedTime + CurrentLapTrackingTime;
    public TimeSpan Total => CurrentLap + PreviousLapsTotal;
    public IReadOnlyCollection<TimeSpan> PreviousLaps => _previousLaps.AsReadOnly();

    public void Start()
    {
        if (State == StopwatchState.Running)
            throw new InvalidOperationException();
        
        _currentLapTrackingTimeSince = time.GetUtcNow();

        State = StopwatchState.Running;
    }

    public void Stop()
    {
        if (State != StopwatchState.Running)
            throw new InvalidOperationException();

        _currentLapTrackedTime += CurrentLap;
        _currentLapTrackingTimeSince = null;
        
        State = StopwatchState.Stopped;
    }

    public void Reset()
    {
        if (State != StopwatchState.Stopped)
            throw new InvalidOperationException();
        
        _previousLaps.Clear();
        _currentLapTrackingTimeSince = null;
        _currentLapTrackedTime = TimeSpan.Zero;
        
        State = StopwatchState.Ready;
    }

    public void Lap()
    {
        if (State != StopwatchState.Running)
            throw new InvalidOperationException();
        
        _previousLaps.Add(CurrentLap);
        _currentLapTrackedTime = TimeSpan.Zero;
        _currentLapTrackingTimeSince = time.GetUtcNow();
    }
}
