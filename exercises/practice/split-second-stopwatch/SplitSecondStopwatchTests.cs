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
    public void TotalIsInitiallyZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(TimeSpan.Zero, stopwatch.Total);
    }

    [Fact]
    public void StartChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }
    
    [Fact]
    public void StartDoesNotChangeLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void StartStartsTimeTrackingInCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed = TimeSpan.FromSeconds(55.5);
        timeProvider.Advance(elapsed);
        
        Assert.Equal(elapsed, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void StartStartsTimeTrackingInTotal()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed = TimeSpan.FromSeconds(55.5);
        timeProvider.Advance(elapsed);
        
        Assert.Equal(elapsed, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void CannotStartFromRunningState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        
        Assert.Throws<InvalidOperationException>(() => stopwatch.Start());
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
    public void StopDoesNotChangeLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        
        stopwatch.Stop();
        
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void StopStopsTimeTrackingInCurrentLap()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed1 = TimeSpan.FromSeconds(22.5);
        timeProvider.Advance(elapsed1);
        
        stopwatch.Stop();
        
        var elapsed2 = TimeSpan.FromSeconds(17.9);
        timeProvider.Advance(elapsed2);
        
        Assert.Equal(elapsed1, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void StopStopsTimeTrackingInTotal()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed1 = TimeSpan.FromSeconds(22.5);
        timeProvider.Advance(elapsed1);
        
        stopwatch.Stop();
        
        var elapsed2 = TimeSpan.FromSeconds(17.9);
        timeProvider.Advance(elapsed2);
        
        Assert.Equal(elapsed1, stopwatch.Total);
    }
    
    [Fact]
    public void CannotStopFromReadyState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        
        Assert.Throws<InvalidOperationException>(() => stopwatch.Stop());
    }
    
    [Fact]
    public void ResetClearsPreviousLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        
        stopwatch.Reset();
        
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void ResetSetsCurrentLapToZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        
        stopwatch.Reset();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void ResetSetsTotalToZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        stopwatch.Stop();
        
        stopwatch.Reset();
        
        Assert.Equal(TimeSpan.Zero, stopwatch.Total);
    }
    
    [Fact]
    public void LapAddsCurrentLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed1 = TimeSpan.FromSeconds(22.5);
        timeProvider.Advance(elapsed1);
        
        stopwatch.Lap();
        
        var elapsed2 = TimeSpan.FromSeconds(17.9);
        timeProvider.Advance(elapsed2);

        var lap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsed1, lap);
    }
    
    [Fact]
    public void LapReSetsCurrentLapStartTimeToCurrentTime()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed1 = TimeSpan.FromSeconds(22.5);
        timeProvider.Advance(elapsed1);
        
        stopwatch.Lap();
        
        var elapsed2 = TimeSpan.FromSeconds(17.9);
        timeProvider.Advance(elapsed2);
        
        Assert.Equal(elapsed2, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void LapDoesNotStopTimeTrackingInTotal()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
    
        var elapsed1 = TimeSpan.FromSeconds(22.5);
        timeProvider.Advance(elapsed1);
        
        stopwatch.Lap();
        
        var elapsed2 = TimeSpan.FromSeconds(17.9);
        timeProvider.Advance(elapsed2);
        
        Assert.Equal(elapsed1 + elapsed2, stopwatch.Total);
    }
}
