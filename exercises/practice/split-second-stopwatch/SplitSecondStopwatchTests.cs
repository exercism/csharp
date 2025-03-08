using Microsoft.Extensions.Time.Testing;

public class SplitSecondStopwatchTests
{
    [Fact]
    public void StateIsInitiallyReady()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }
    
    [Fact]
    public void PreviousLapsIsInitiallyEmpty()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void CurrentLapIsInitiallyZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void StartFromReadyStateChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }
    
    [Fact]
    public void StartFromReadyStateDoesNotChangePreviousLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void StartFromReadyStateStartsTimeTrackingInCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        var elapsed = TimeSpan.FromSeconds(55.5);
        timeProvider.Advance(elapsed);
        
        Assert.Equal(elapsed, stopwatch.CurrentLap);
    }

    [Fact]
    public void StopFromRunningStateChangesStateToReady()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();

        stopwatch.Stop();

        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }
    
    [Fact]
    public void StopFromRunningStateAddsCurrentLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);
        
        stopwatch.Stop();
    
        var previousLap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsed, previousLap);
    }

    [Fact]
    public void StopFromRunningStateResetsCurrentLapToZero()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        stopwatch.Stop();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void PauseFromRunningStateChangesStateToPaused()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();

        stopwatch.Pause();

        Assert.Equal(StopwatchState.Paused, stopwatch.State);
    }
    
    [Fact]
    public void PauseFromRunningStateDoesNotChangePreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);
        
        stopwatch.Pause();
    
        Assert.Empty(stopwatch.PreviousLaps);
    }

    [Fact]
    public void PauseFromRunningStateFreezesCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);
        
        stopwatch.Pause();
        
        timeProvider.Advance(TimeSpan.FromSeconds(17.7));
        
        Assert.Equal(elapsed, stopwatch.CurrentLap);
    }
    
    
    
    [Fact]
    public void StartFromPausedStateChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Pause();
        
        stopwatch.Start();
        
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }
    
    [Fact]
    public void StartFromPausedStateDoesNotChangePreviousLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Pause();
        
        stopwatch.Start();
        
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void StartFromPausedStateResumesTimeTrackingInCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed1 = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed1);
        
        stopwatch.Pause();
        
        var elapsed2 = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed2);
        
        stopwatch.Start();

        var elapsed3 = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed3);
        
        Assert.Equal(elapsed1 + elapsed3, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void StopFromPausedStateChangesStateToReady()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Pause();

        stopwatch.Stop();

        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }

    [Fact]
    public void StopFromPausedStateResetsCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        stopwatch.Pause();
        
        stopwatch.Stop();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void StopFromPausedStateAddsCurrentLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);
        stopwatch.Pause();

        timeProvider.Advance(TimeSpan.FromSeconds(44.4));
        stopwatch.Stop();
    
        var recordedLap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsed, recordedLap);
    }
    
    [Fact]
    public void SplitFromRunningStateAddsCurrentLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);

        stopwatch.Split();
    
        var recordedLap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsed, recordedLap);
    }
    
    [Fact]
    public void SplitFromRunningStateDoesNotChangeState()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);

        stopwatch.Split();
    
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }
    
    [Fact]
    public void SplitFromPausedStateAddsCurrentLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);
        stopwatch.Pause();

        timeProvider.Advance(TimeSpan.FromSeconds(44.4));
        stopwatch.Split();
    
        var recordedLap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsed, recordedLap);
    }

    [Fact]
    public void SplitFromRunningStateResetsCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        stopwatch.Pause();
        
        stopwatch.Split();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }

    [Fact]
    public void SplitFromPausedStateResetsCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        stopwatch.Pause();
        
        stopwatch.Split();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void SplitFromRunningStateImmediatelyStartsNewLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        
        var elapsed1 = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed1);

        stopwatch.Split();
        
        var elapsed2 = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed2);
    
        Assert.Equal(elapsed2, stopwatch.CurrentLap);
    }

    [Fact]
    public void CurrentLapDoesNotTrackElapsedTimeInReadyState()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);

        timeProvider.Advance(TimeSpan.FromSeconds(55.5));
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void StartFromRunningStateIsInvalid()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        
        Assert.Throws<InvalidOperationException>(() => stopwatch.Start());
    }
    
    public void StopFromReadyStateIsInvalid()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Throws<InvalidOperationException>(() => stopwatch.Stop());
    }
    
    public void PauseFromReadyStateIsInvalid()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Throws<InvalidOperationException>(() => stopwatch.Pause());
    }
    
    public void SplitFromReadyStateIsInvalid()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Throws<InvalidOperationException>(() => stopwatch.Split());
    }
}
