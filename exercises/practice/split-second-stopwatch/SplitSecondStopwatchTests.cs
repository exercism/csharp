using Microsoft.Extensions.Time.Testing;

public class SplitSecondStopwatchTests
{
    [Fact]
    public void NewStopwatchIsInReadyState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }
    
    [Fact]
    public void NewStopwatchHasNoPreviousLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void NewStopwatchHasCurrentLapSetToZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }

    [Fact]
    public void StartWhenStateIsReadyChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact]
    public void StartWhenStateIsStoppedChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        
        stopwatch.Start();
        
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }
    
    [Fact]
    public void StartWhenStateIsPausedChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Pause();
 
        stopwatch.Start();
        
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact]
    public void StartWhenStateIsRunningDoesNotChangeState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        
        stopwatch.Start();
        
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact]
    public void StopWhenStateIsReadyDoesNotChangeState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Stop();
        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }

    [Fact]
    public void StopWhenStateIsStoppedDoesNotChangeState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        
        stopwatch.Stop();
        
        Assert.Equal(StopwatchState.Stopped, stopwatch.State);
    }
    
    [Fact]
    public void StopWhenStateIsPausedChangesStateToStopped()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Pause();
 
        stopwatch.Stop();
        
        Assert.Equal(StopwatchState.Stopped, stopwatch.State);
    }

    [Fact]
    public void StopWhenStateIsRunningChangesStateToStopped()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        
        stopwatch.Stop();
        
        Assert.Equal(StopwatchState.Stopped, stopwatch.State);
    }

    [Fact]
    public void StopAddsLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        stopwatch.Stop();
        
        Assert.Single(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void StopResetsCurrentLapToZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        
        stopwatch.Stop();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void CurrentLapReturnsTimeElapsedSinceStart()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        var elapsed = TimeSpan.FromSeconds(5);
        timeProvider.Advance(elapsed);
        
        Assert.Equal(elapsed, stopwatch.CurrentLap);
    }

    [Fact]
    public void PauseStopsTimeOfCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        var elapsed = TimeSpan.FromSeconds(5);
        timeProvider.Advance(elapsed);
        
        stopwatch.Pause();
        
        timeProvider.Advance(TimeSpan.FromSeconds(10));
        
        Assert.Equal(elapsed, stopwatch.CurrentLap);
    }

    [Fact]
    public void StartAfterPauseResumesCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        var elapsedBefore = TimeSpan.FromSeconds(5);
        timeProvider.Advance(elapsedBefore);
        
        stopwatch.Pause();
        
        timeProvider.Advance(TimeSpan.FromSeconds(10));
        
        stopwatch.Start();
        
        var elapsedAfter = TimeSpan.FromSeconds(3);
        timeProvider.Advance(elapsedAfter);
        
        stopwatch.Stop();

        var lap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsedBefore + elapsedAfter, lap);
    }
    
    [Fact]
    public void EachStartStopCallAddsLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);

        for (var i = 0; i < 10; i++)
        {
            stopwatch.Start();
            stopwatch.Stop();
        }
        
        Assert.Equal(10, stopwatch.PreviousLaps.Count);
    }
}
