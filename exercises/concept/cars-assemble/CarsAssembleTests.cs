using Xunit;
using Exercism.Tests;

public class CarsAssembleTests
{
    [Fact]
    [Task(1)]
    public void Success_rate_for_speed_zero()
    {
        Assert.Equal(0.0, AssemblyLine.SuccessRate(0), precision:1);
    }
    
    [Fact]
    [Task(1)]
    public void Success_rate_for_speed_one()
    {
        Assert.Equal(1.0, AssemblyLine.SuccessRate(1), precision:1);
    }
    
    [Fact]
    [Task(1)]
    public void Success_rate_for_speed_four()
    {
        Assert.Equal(1.0, AssemblyLine.SuccessRate(4), precision:1);
    }
    
    [Fact]
    [Task(1)]
    public void Success_rate_for_speed_five()
    {
        Assert.Equal(0.9, AssemblyLine.SuccessRate(5), precision:1);
    }
    
    [Fact]
    [Task(1)]
    public void Success_rate_for_speed_nine()
    {
        Assert.Equal(0.8, AssemblyLine.SuccessRate(9), precision:1);
    }
    
    [Fact]
    [Task(1)]
    public void Success_rate_for_speed_ten()
    {
        Assert.Equal(0.77, AssemblyLine.SuccessRate(10), precision:2);
    }
    
    [Fact]
    [Task(2)]
    public void Production_rate_per_hour_for_speed_zero()
    {
        Assert.Equal(0.0, AssemblyLine.ProductionRatePerHour(0), precision: 1);
    }

    [Fact]
    [Task(2)]
    public void Production_rate_per_hour_for_speed_one()
    {
        Assert.Equal(221.0, AssemblyLine.ProductionRatePerHour(1), precision: 1);
    }

    [Fact]
    [Task(2)]
    public void Production_rate_per_hour_for_speed_four()
    {
        Assert.Equal(884.0, AssemblyLine.ProductionRatePerHour(4), precision: 1);
    }

    [Fact]
    [Task(2)]
    public void Production_rate_per_hour_for_speed_seven()
    {
        Assert.Equal(1392.3, AssemblyLine.ProductionRatePerHour(7), precision: 1);
    }

    [Fact]
    [Task(2)]
    public void Production_rate_per_hour_for_speed_nine()
    {
        Assert.Equal(1591.2, AssemblyLine.ProductionRatePerHour(9), precision: 1);
    }

    [Fact]
    [Task(2)]
    public void Production_rate_per_hour_for_speed_ten()
    {
        Assert.Equal(1701.7, AssemblyLine.ProductionRatePerHour(10), precision: 1);
    }

    [Fact]
    [Task(3)]
    public void Working_items_per_minute_for_speed_zero()
    {
        Assert.Equal(0, AssemblyLine.WorkingItemsPerMinute(0));
    }

    [Fact]
    [Task(3)]
    public void Working_items_per_minute_for_speed_one()
    {
        Assert.Equal(3, AssemblyLine.WorkingItemsPerMinute(1));
    }

    [Fact]
    [Task(3)]
    public void Working_items_per_minute_for_speed_five()
    {
        Assert.Equal(16, AssemblyLine.WorkingItemsPerMinute(5));
    }

    [Fact]
    [Task(3)]
    public void Working_items_per_minute_for_speed_eight()
    {
        Assert.Equal(26, AssemblyLine.WorkingItemsPerMinute(8));
    }
    [Fact]
    [Task(3)]
    public void Working_items_per_minute_for_speed_nine()
    {
        Assert.Equal(26, AssemblyLine.WorkingItemsPerMinute(9));
    }

    [Fact]
    [Task(3)]
    public void Working_items_per_minute_for_speed_ten()
    {
        Assert.Equal(28, AssemblyLine.WorkingItemsPerMinute(10));
    }
}
