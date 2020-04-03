using Xunit;

public class AssemblyLineTests
{
    [Fact]
    public void ProductionRatePerHourForSpeedZero() =>
        Assert.Equal(0.0, AssemblyLine.ProductionRatePerHour(0));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ProductionRatePerHourForSpeedOne() =>
        Assert.Equal(221.0, AssemblyLine.ProductionRatePerHour(1));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ProductionRatePerHourForSpeedFour() =>
        Assert.Equal(884.0, AssemblyLine.ProductionRatePerHour(4));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ProductionRatePerHourForSpeedSeven() =>
        Assert.Equal(1392.3, AssemblyLine.ProductionRatePerHour(7));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void ProductionRatePerHourForSpeedNine() =>
        Assert.Equal(1531.53, AssemblyLine.ProductionRatePerHour(9));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WorkingItemsPerMinuteForSpeedZero() =>
        Assert.Equal(0, AssemblyLine.WorkingItemsPerMinute(0));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WorkingItemsPerMinuteForSpeedOne() =>
        Assert.Equal(3, AssemblyLine.WorkingItemsPerMinute(1));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WorkingItemsPerMinuteForSpeedFive() =>
        Assert.Equal(16, AssemblyLine.WorkingItemsPerMinute(5));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WorkingItemsPerMinuteForSpeedEight() =>
        Assert.Equal(26, AssemblyLine.WorkingItemsPerMinute(8));

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void WorkingItemsPerMinuteForSpeedTen() =>
        Assert.Equal(28, AssemblyLine.WorkingItemsPerMinute(10));
}
