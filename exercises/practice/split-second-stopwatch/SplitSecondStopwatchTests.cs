using Microsoft.Extensions.Time.Testing;
using Xunit.Runner.Common;

public class SplitSecondStopwatchTests
{
    [Fact]
    public void NewStopwatchIsInReadyState()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }
    
    [Fact]
    public void NewStopwatchHasCurrentLapSetToZero()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
    
    [Fact]
    public void NewStopwatchHasNoPreviousLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        Assert.Empty(stopwatch.PreviousLaps);
    }

    [Fact]
    public void StartFromReadyStateChangesStateToRunning()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }
    
    [Fact]
    public void StartDoesNotModifyPreviousLaps()       
    {
        var stopwatch = new SplitSecondStopwatch(new FakeTimeProvider());
        stopwatch.Start();
        Assert.Empty(stopwatch.PreviousLaps);
    }
    
    [Fact]
    public void CurrentLapContainsTimeElapsedSinceStart()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        var elapsed1 = TimeSpan.FromSeconds(5.2);
        timeProvider.Advance(elapsed1);
        
        Assert.Equal(elapsed1, stopwatch.CurrentLap);
        
        var elapsed2 = TimeSpan.FromSeconds(3.4);
        timeProvider.Advance(elapsed2);
        
        Assert.Equal(elapsed1 + elapsed2, stopwatch.CurrentLap);
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
    public void StopAddsCurrentLapToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();
        var elapsed = TimeSpan.FromSeconds(33.6);
        timeProvider.Advance(elapsed);
        
        stopwatch.Stop();

        var recordedLap = Assert.Single(stopwatch.PreviousLaps);
        Assert.Equal(elapsed, recordedLap);
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
    public void MultipleStartStopCyclesAddsEachLapTimeToPreviousLaps()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        
        List<TimeSpan> expectedLapTimes = [];
        const int numberOfLaps = 8;

        for (var i = 0; i < numberOfLaps; i++)
        {
            stopwatch.Start();
            var elapsed = TimeSpan.FromSeconds(i * 1.1);
            timeProvider.Advance(elapsed);
            expectedLapTimes.Add(elapsed);
            stopwatch.Stop();
        }

        for (var i = 0; i < numberOfLaps; i++)
        {
            Assert.Equal(expectedLapTimes[i], stopwatch.PreviousLaps[i]);
        }
    }

    [Fact]
    public void CurrentLapDoesNotTrackTimeElapsedInReadyState()       
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        timeProvider.Advance(TimeSpan.FromSeconds(55.5));
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }
}
