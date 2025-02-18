using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Xunit;
using Exercism.Tests;

public class BeautySalonGoesGlobalTests
{
    public BeautySalonGoesGlobalTests()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
    }

    [Fact]
    [Task(1)]
    public void ShowLocalTime()
    {
        var dt = new DateTime(2030, 07, 25, 13, 45, 0);
        var tzi = TimeZoneInfo.Local;
        var offset = tzi.GetUtcOffset(dt);
        Assert.Equal(dt + offset, Appointment.ShowLocalTime(dt));
    }

    [Fact]
    [Task(2)]
    public void Schedule_newyork()
    {
        Assert.Equal(new DateTime(2019, 07, 25, 12, 45, 0),
            Appointment.Schedule("7/25/2019 08:45:00", Location.NewYork));
    }

    [Fact]
    [Task(2)]
    public void Schedule_london()
    {
        Assert.Equal(new DateTime(2019, 07, 25, 12, 45, 0),
            Appointment.Schedule("7/25/2019 13:45:00", Location.London));
    }

    [Fact]
    [Task(2)]
    public void Schedule_paris()
    {
        Assert.Equal(new DateTime(2019, 07, 25, 12, 45, 0),
            Appointment.Schedule("7/25/2019 14:45:00", Location.Paris));
    }

    [Fact]
    [Task(3)]
    public void GetAlertTime_early()
    {
        Assert.Equal(new DateTime(2019, 07, 24, 16, 0, 0),
            Appointment.GetAlertTime(new DateTime(2019, 7, 25, 16, 0, 0),
                AlertLevel.Early));
    }

    [Fact]
    [Task(3)]
    public void GetAlertTime_standard()
    {
        Assert.Equal(new DateTime(2019, 07, 25, 14, 15, 0),
            Appointment.GetAlertTime(new DateTime(2019, 7, 25, 16, 0, 0),
                AlertLevel.Standard));
    }

    [Fact]
    [Task(3)]
    public void GetAlertTime_late()
    {
        Assert.Equal(new DateTime(2019, 07, 25, 15, 30, 0),
            Appointment.GetAlertTime(new DateTime(2019, 7, 25, 16, 0, 0),
                AlertLevel.Late));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_newyork_active()
    {
        Assert.True(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 3, 13, 0, 0, 0),
                Location.NewYork));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_newyork_inactive()
    {
        Assert.True(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 11, 7, 0, 0, 0),
                Location.NewYork));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_newyork_no_change()
    {
        Assert.False(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 12, 25, 0, 0, 0),
                Location.NewYork));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_london_active()
    {
        Assert.True(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 4, 1, 0, 0, 0),
                Location.London));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_london_inactive()
    {
        Assert.True(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 10, 29, 0, 0, 0),
                Location.London));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_london_no_change()
    {
        Assert.False(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 12, 25, 0, 0, 0),
                Location.London));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_paris_active()
    {
        Assert.True(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 4, 1, 0, 0, 0),
                Location.Paris));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_paris_inactive()
    {
        Assert.True(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 10, 29, 0, 0, 0),
                Location.Paris));
    }

    [Fact]
    [Task(4)]
    public void DaylightSavingChanged_paris_no_change()
    {
        Assert.False(
            Appointment.HasDaylightSavingChanged(new DateTime(2019, 12, 25, 0, 0, 0),
                Location.Paris));
    }

    [Fact]
    [Task(5)]
    public void NormalizeDateTime_newyork()
    {
        Assert.Equal(new DateTime(2019, 11, 25, 13, 45, 0),
            Appointment.NormalizeDateTime("11/25/2019 13:45:00",
                Location.NewYork));
    }

    [Fact]
    [Task(5)]
    public void NormalizeDateTime_london()
    {
        Assert.Equal(new DateTime(2019, 11, 25, 13, 45, 0),
            Appointment.NormalizeDateTime("25/11/2019 13:45:00",
                Location.London));
    }

    [Fact]
    [Task(5)]
    public void NormalizeDateTime_paris()
    {
        Assert.Equal(new DateTime(2019, 11, 25, 13, 45, 0),
            Appointment.NormalizeDateTime("25/11/2019 13:45:00",
                Location.Paris));
    }

    [Fact]
    [Task(5)]
    public void NormalizeDateTime_bad()
    {
        Assert.Equal(DateTime.MinValue,
            Appointment.NormalizeDateTime("25/11/2019 13:45:00",
                Location.NewYork));
    }

    private static IList<string> GetTimeZoneIds()
    {
        return TimeZoneInfo.GetSystemTimeZones().Select(tzi => tzi.Id).OrderBy(tzi => tzi).ToList();
    }
}
