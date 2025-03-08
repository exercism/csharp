using Microsoft.Extensions.Time.Testing;

public class SplitSecondStopwatchTests
{
    [Fact]
    public void InitalStateIsReady()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }

    [Fact]
    public void StartChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact]
    public void PauseChangesStateToPaused()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Pause();
        Assert.Equal(StopwatchState.Paused, stopwatch.State);
    }

    [Fact]
    public void SplitKeepsStateAsRunning()
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Split();
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact]
    public void StopChangesStateToStop()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        Assert.Equal(StopwatchState.Stopped, stopwatch.State);
    }

    [Fact]
    public void StopAddsLapTime()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        Assert.Equal(StopwatchState.Stopped, stopwatch.State);
    }
}
