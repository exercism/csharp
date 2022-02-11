using System;
using Xunit;
using Exercism.Tests;

public class TheWeatherInDeatherTests
{
    [Fact]
    [Task(1)]
    public void GetReading()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(20m, 25m, 0.01m, WindDirection.Unknown));
        decimal[] expected = { 20, 25, 0.01m };
        decimal[] actual = { ws.LatestTemperature, ws.LatestPressure, ws.LatestRainfall };
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Task(1)]
    public void HasHistory_no()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(20m, 25m, 0.01m, WindDirection.Unknown));
        Assert.False(ws.HasHistory);
    }

    [Fact]
    [Task(1)]
    public void HasHistory_yes()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(20m, 25m, 0.01m, WindDirection.Unknown));
        ws.AcceptReading(new Reading(21m, 25m, 0.00m, WindDirection.Unknown));
        Assert.True(ws.HasHistory);
    }

    [Fact]
    [Task(1)]
    public void ClearAll()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(20m, 25m, 0.01m, WindDirection.Unknown));
        ws.AcceptReading(new Reading(21m, 25m, 0.00m, WindDirection.Unknown));
        ws.ClearAll();
        object[] expected = { false, 0m };
        object[] actual = { ws.HasHistory, ws.LatestTemperature };
        Assert.Equal(expected, actual);
    }

    [Fact]
    [Task(1)]
    public void ShortTermOutlook_exception()
    {
        var ws = new WeatherStation();
        Assert.Throws<ArgumentException>(() => ws.ShortTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void ShortTermOutlook_cool()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(7m, 7m, 0m, WindDirection.Unknown));
        Assert.Equal(Outlook.Cool, ws.ShortTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void ShortTermOutlook_good()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(55m, 7m, 0m, WindDirection.Unknown));
        Assert.Equal(Outlook.Good, ws.ShortTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void ShortTermOutlook_warm()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(40m, 7m, 0m, WindDirection.Unknown));
        Assert.Equal(Outlook.Warm, ws.ShortTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void RunSelfTest_good()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(40m, 7m, 0m, WindDirection.Unknown));
        Assert.Equal(State.Good, ws.RunSelfTest());
    }

    [Fact]
    [Task(1)]
    public void RunSelfTest_bad()
    {
        var ws = new WeatherStation();
        Assert.Equal(State.Bad, ws.RunSelfTest());
    }

    [Fact]
    [Task(1)]
    public void LongTermOutlook_exception()
    {
        var ws = new WeatherStation();
        Assert.Throws<ArgumentException>(() => ws.LongTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void LongTermOutlook_cool()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(7m, 7m, 0m, WindDirection.Northerly));
        Assert.Equal(Outlook.Cool, ws.LongTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void LongTermOutlook_good()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(21m, 7m, 0m, WindDirection.Easterly));
        Assert.Equal(Outlook.Good, ws.LongTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void LongTermOutlook_good2()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(7m, 7m, 0m, WindDirection.Southerly));
        Assert.Equal(Outlook.Good, ws.LongTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void LongTermOutlook_warm()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(7m, 7m, 0m, WindDirection.Easterly));
        Assert.Equal(Outlook.Warm, ws.LongTermOutlook);
    }

    [Fact]
    [Task(1)]
    public void LongTermOutlook_rainy()
    {
        var ws = new WeatherStation();
        ws.AcceptReading(new Reading(21m, 7m, 0m, WindDirection.Westerly));
        Assert.Equal(Outlook.Rainy, ws.LongTermOutlook);
    }
}
