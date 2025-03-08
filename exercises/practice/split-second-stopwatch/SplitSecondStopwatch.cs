public enum StopwatchState
{
    Ready,
    Running,
    Paused,
    Stopped
}

public class SplitSecondStopwatch(TimeProvider time)
{
    public StopwatchState State { get; private set; }

    public void Start()
    {
        throw new NotImplementedException();
    }

    public void Stop()
    {
        throw new NotImplementedException();
    }

    public void Split()
    {
        throw new NotImplementedException();
    }

    public void Pause()
    {
        throw new NotImplementedException();
    }
}
