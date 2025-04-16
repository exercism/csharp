using Microsoft.Extensions.Time.Testing;

public class SplitSecondStopwatchTests
{
    [Fact]
    public void New_stopwatch_starts_in_ready_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void New_stopwatch_s_current_lap_has_no_elapsed_time()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void New_stopwatch_s_total_has_no_elapsed_time()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Equal(TimeSpan.Zero, stopwatch.Total);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void New_stopwatch_does_not_have_previous_laps()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Empty(stopwatch.PreviousLaps);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_from_ready_state_changes_state_to_running()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_does_not_change_previous_laps()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        Assert.Empty(stopwatch.PreviousLaps);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_initiates_time_tracking_for_current_lap()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 5));
        Assert.Equal(new TimeSpan(0, 0, 5), stopwatch.CurrentLap);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_initiates_time_tracking_for_total()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 23));
        Assert.Equal(new TimeSpan(0, 0, 23), stopwatch.Total);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_cannot_be_called_from_running_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        Assert.Throws<InvalidOperationException>(() => stopwatch.Start());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_from_running_state_changes_state_to_stopped()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        stopwatch.Stop();

        Assert.Equal(StopwatchState.Stopped, stopwatch.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_pauses_time_tracking_for_current_lap()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 5));
        stopwatch.Stop();

        timeProvider.Advance(new TimeSpan(0, 0, 8));
        Assert.Equal(new TimeSpan(0, 0, 5), stopwatch.CurrentLap);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_pauses_time_tracking_for_total()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 13));
        stopwatch.Stop();

        timeProvider.Advance(new TimeSpan(0, 0, 44));
        Assert.Equal(new TimeSpan(0, 0, 13), stopwatch.Total);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_cannot_be_called_from_ready_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Throws<InvalidOperationException>(() => stopwatch.Stop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_cannot_be_called_from_stopped_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        stopwatch.Stop();

        Assert.Throws<InvalidOperationException>(() => stopwatch.Stop());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_from_stopped_state_changes_state_to_running()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        stopwatch.Stop();

        stopwatch.Start();

        Assert.Equal(StopwatchState.Running, stopwatch.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_from_stopped_state_resumes_time_tracking_for_current_lap()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 1, 20));
        stopwatch.Stop();

        timeProvider.Advance(new TimeSpan(0, 0, 20));
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 8));
        Assert.Equal(new TimeSpan(0, 1, 28), stopwatch.CurrentLap);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Start_from_stopped_state_resumes_time_tracking_for_total()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 23));
        stopwatch.Stop();

        timeProvider.Advance(new TimeSpan(0, 0, 44));
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 9));
        Assert.Equal(new TimeSpan(0, 0, 32), stopwatch.Total);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lap_adds_current_lap_to_previous_laps()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 1, 38));
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(0, 1, 38)], stopwatch.PreviousLaps);

        timeProvider.Advance(new TimeSpan(0, 0, 44));
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(0, 1, 38), new TimeSpan(0, 0, 44)], stopwatch.PreviousLaps);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lap_resets_current_lap_and_resumes_time_tracking()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 8, 22));
        stopwatch.Lap();

        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
        timeProvider.Advance(new TimeSpan(0, 0, 15));
        Assert.Equal(new TimeSpan(0, 0, 15), stopwatch.CurrentLap);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lap_continues_time_tracking_for_total()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 22));
        stopwatch.Lap();

        timeProvider.Advance(new TimeSpan(0, 0, 33));
        Assert.Equal(new TimeSpan(0, 0, 55), stopwatch.Total);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lap_cannot_be_called_from_ready_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Throws<InvalidOperationException>(() => stopwatch.Lap());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Lap_cannot_be_called_from_stopped_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        stopwatch.Stop();

        Assert.Throws<InvalidOperationException>(() => stopwatch.Lap());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Stop_does_not_change_previous_laps()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 11, 22));
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(0, 11, 22)], stopwatch.PreviousLaps);

        stopwatch.Stop();

        Assert.Equal([new TimeSpan(0, 11, 22)], stopwatch.PreviousLaps);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reset_from_stopped_state_changes_state_to_ready()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        stopwatch.Stop();

        stopwatch.Reset();

        Assert.Equal(StopwatchState.Ready, stopwatch.State);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reset_resets_current_lap()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 10));
        stopwatch.Stop();

        stopwatch.Reset();

        Assert.Equal(TimeSpan.Zero, stopwatch.CurrentLap);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reset_clears_previous_laps()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(0, 0, 10));
        stopwatch.Lap();

        timeProvider.Advance(new TimeSpan(0, 0, 20));
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(0, 0, 10), new TimeSpan(0, 0, 20)], stopwatch.PreviousLaps);

        stopwatch.Stop();

        stopwatch.Reset();

        Assert.Empty(stopwatch.PreviousLaps);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reset_cannot_be_called_from_ready_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        Assert.Throws<InvalidOperationException>(() => stopwatch.Reset());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Reset_cannot_be_called_from_running_state()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        Assert.Throws<InvalidOperationException>(() => stopwatch.Reset());
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Supports_very_long_laps()
    {
        var timeProvider = new FakeTimeProvider();
        var stopwatch = new SplitSecondStopwatch(timeProvider);
        stopwatch.Start();

        timeProvider.Advance(new TimeSpan(1, 23, 45));
        Assert.Equal(new TimeSpan(1, 23, 45), stopwatch.CurrentLap);
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(1, 23, 45)], stopwatch.PreviousLaps);

        timeProvider.Advance(new TimeSpan(4, 1, 40));
        Assert.Equal(new TimeSpan(4, 1, 40), stopwatch.CurrentLap);
        Assert.Equal(new TimeSpan(5, 25, 25), stopwatch.Total);
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(1, 23, 45), new TimeSpan(4, 1, 40)], stopwatch.PreviousLaps);

        timeProvider.Advance(new TimeSpan(8, 43, 5));
        Assert.Equal(new TimeSpan(8, 43, 5), stopwatch.CurrentLap);
        Assert.Equal(new TimeSpan(14, 8, 30), stopwatch.Total);
        stopwatch.Lap();

        Assert.Equal([new TimeSpan(1, 23, 45), new TimeSpan(4, 1, 40), new TimeSpan(8, 43, 5)], stopwatch.PreviousLaps);
    }
}
