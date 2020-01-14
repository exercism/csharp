using Xunit;

public class AssemblyLineTest
{
    [Fact]
    public void ProductionRatePerHourForSpeedZero() =>
        Assert.Equal(0.0, AssemblyLine.ProductionRatePerHour(0));

    [Fact]
    public void ProductionRatePerHourForSpeedOne() =>
        Assert.Equal(221.0, AssemblyLine.ProductionRatePerHour(1));

    [Fact]
    public void ProductionRatePerHourForSpeedFour() =>
        Assert.Equal(884.0, AssemblyLine.ProductionRatePerHour(4));

    [Fact]
    public void ProductionRatePerHourForSpeedSeven() =>
        Assert.Equal(1392.3, AssemblyLine.ProductionRatePerHour(7));

    [Fact]
    public void ProductionRatePerHourForSpeedNine() =>
        Assert.Equal(1531.53, AssemblyLine.ProductionRatePerHour(9));

    [Fact]
    public void WorkingItemsPerMinuteForSpeedZero() =>
        Assert.Equal(0, AssemblyLine.WorkingItemsPerMinute(0));

    [Fact]
    public void WorkingItemsPerMinuteForSpeedOne() =>
        Assert.Equal(3, AssemblyLine.WorkingItemsPerMinute(1));

    [Fact]
    public void WorkingItemsPerMinuteForSpeedFive() =>
        Assert.Equal(16, AssemblyLine.WorkingItemsPerMinute(5));

    [Fact]
    public void WorkingItemsPerMinuteForSpeedFour() =>
        Assert.Equal(26, AssemblyLine.WorkingItemsPerMinute(8));

    [Fact]
    public void WorkingItemsPerMinuteForSpeedTen() =>
        Assert.Equal(28, AssemblyLine.WorkingItemsPerMinute(10));
}