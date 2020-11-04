using System;
using Xunit;

public class WeighingMachineTests
{
    [Fact]
    public void Set_weight_and_get_weight()
    {
        var wm = new WeighingMachine();
        wm.InputWeight = 60m;
        Assert.Equal(60m, wm.InputWeight, precision: 3);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_weight_is_invalid()
    {
        var wm = new WeighingMachine();
        Assert.Throws<ArgumentException>(() => wm.InputWeight = -10);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Get_us_display_weight_pounds()
    {
        var wm = new WeighingMachine();
        wm.InputWeight = 60m;
        Assert.Equal(132, wm.USDisplayWeight.Pounds);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Get_us_display_weight_ounces()
    {
        var wm = new WeighingMachine();
        wm.InputWeight = 60m;
        Assert.Equal(4, wm.USDisplayWeight.Ounces);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Input_pounds_and_get_us_display_weight_pounds()
    {
        var wm = new WeighingMachine();
        wm.Units = Units.Pounds;
        wm.InputWeight = 175.5m;
        Assert.Equal(175, wm.USDisplayWeight.Pounds);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Input_pounds_and_get_is_display_weight_ounces()
    {
        var wm = new WeighingMachine();
        wm.Units = Units.Pounds;
        wm.InputWeight = 175.5m;
        Assert.Equal(8, wm.USDisplayWeight.Ounces);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine();
        wm.InputWeight = 100;
        wm.TareAdjustment = 10;
        Assert.Equal(90, wm.DisplayWeight);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_negative_tare_adjustment()
    {
        var wm = new WeighingMachine();
        wm.InputWeight = 100;
        wm.TareAdjustment = -10;
        Assert.Equal(110, wm.DisplayWeight);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_large_tare_adjustment_to_allow_negative_display_weight()
    {
        var wm = new WeighingMachine();
        wm.InputWeight = 100;
        wm.TareAdjustment = 110;
        Assert.Equal(-10, wm.DisplayWeight);
    }
}
