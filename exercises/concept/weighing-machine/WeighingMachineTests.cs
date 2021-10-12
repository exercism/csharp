using System;
using Xunit;
using Exercism.Tests;

public class WeighingMachineTests
{
    [Fact]
    public void Get_Precision()
    {
        var wm = new WeighingMachine(precision:"3");
        Assert.Equal("3", wm.Precision);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Set_weight_and_get_weight()
    {
        var wm = new WeighingMachine(precision:"3");
        wm.Weight = 60.5;
        Assert.Equal(60.500, wm.Weight, precision: 3);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_weight_is_invalid()
    {
        var wm = new WeighingMachine(precision:"3");
        Assert.Throws<ArgumentOutOfRangeException>(() => wm.Weight = -10);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine(precision:"3");
        wm.Weight = 100.770;
        wm.TareAdjustment = 10;
        Assert.Equal(90.770, wm.DisplayWeight, precision: 3);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_Default_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine(precision:"3");
        wm.Weight = 100.5;
        Assert.Equal(95.500, wm.DisplayWeight, precision: 3);
    }

    [Fact]
    public void Apply_negative_tare_adjustment()
    {
        var wm = new WeighingMachine(precision:"3");
        wm.Weight = 100;
        wm.TareAdjustment = -10;
        Assert.Equal(110.0, wm.DisplayWeight, precision: 3);
    }

    [Fact]
    public void Apply_large_tare_adjustment_to_allow_negative_display_weight()
    {
        var wm = new WeighingMachine(precision:"3");
        wm.Weight = 100;
        wm.TareAdjustment = 110;
        Assert.Equal(-10.0, wm.DisplayWeight, precision: 3);
    }
}
