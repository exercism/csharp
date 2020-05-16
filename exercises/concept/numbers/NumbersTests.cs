using Xunit;

public class AssemblyLineTests
{
    [Fact]
    public void Production_rate_per_hour_for_speed_zero()
    {
        Assert.Equal(0.0, AssemblyLine.ProductionRatePerHour(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Production_rate_per_hour_for_speed_one()
    {
        Assert.Equal(221.0, AssemblyLine.ProductionRatePerHour(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Production_rate_per_hour_for_speed_four()
    {
        Assert.Equal(884.0, AssemblyLine.ProductionRatePerHour(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Production_rate_per_hour_for_speed_seven()
    {
        Assert.Equal(1392.3, AssemblyLine.ProductionRatePerHour(7));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Production_rate_per_hour_for_speed_nine()
    {
        Assert.Equal(1591.2, AssemblyLine.ProductionRatePerHour(9));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Production_rate_per_hour_for_speed_ten()
    {
        Assert.Equal(1701.7, AssemblyLine.ProductionRatePerHour(10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Working_items_per_minute_for_speed_zero()
    {
        Assert.Equal(0, AssemblyLine.WorkingItemsPerMinute(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Working_items_per_minute_for_speed_one()
    {
        Assert.Equal(3, AssemblyLine.WorkingItemsPerMinute(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Working_items_per_minute_for_speed_five()
    {
        Assert.Equal(16, AssemblyLine.WorkingItemsPerMinute(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Working_items_per_minute_for_speed_eight()
    {
        Assert.Equal(26, AssemblyLine.WorkingItemsPerMinute(8));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Working_items_per_minute_for_speed_nine()
    {
        Assert.Equal(26, AssemblyLine.WorkingItemsPerMinute(9));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Working_items_per_minute_for_speed_ten()
    {
        Assert.Equal(28, AssemblyLine.WorkingItemsPerMinute(10));
    }
}
