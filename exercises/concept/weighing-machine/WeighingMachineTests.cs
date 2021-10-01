using System;
using Xunit;
using Exercism.Tests;

public class WeighingMachineTests
{
    [Fact]
    public void Get_Precision()
    {
        var wm = new WeighingMachine(precision:2);
        Assert.Equal(2, wm.Precision);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Set_weight_and_get_weight()
    {
        var wm = new WeighingMachine();
        wm.Weight = 60m;
        Assert.Equal(60m, wm.Weight, precision: 3);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Negative_weight_is_invalid()
    {
        var wm = new WeighingMachine();
        Assert.Throws<ArgumentOutOfRangeException>(() => wm.Weight = -10);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine();
        wm.Weight = 100;
        wm.TareAdjustment = 10;
        Assert.Equal(90, wm.DisplayWeight);
    }

     [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_Default_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine();
        wm.Weight = 100;
        Assert.Equal(95, wm.DisplayWeight);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_negative_tare_adjustment()
    {
        var wm = new WeighingMachine();
        wm.Weight = 100;
        wm.TareAdjustment = -10;
        Assert.Equal(110, wm.DisplayWeight);
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Apply_large_tare_adjustment_to_allow_negative_display_weight()
    {
        var wm = new WeighingMachine();
        wm.Weight = 100;
        wm.TareAdjustment = 110;
        Assert.Equal(-10, wm.DisplayWeight);
    }
}
