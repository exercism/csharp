using System;
using Xunit;
using Exercism.Tests;

[UseCulture]
public class WeighingMachineTests
{
    [Fact]
    [Task(1)]
    public void Get_Precision()
    {
        var wm = new WeighingMachine(precision: 3);
        Assert.Equal(3, wm.Precision);
    }

    [Fact]
    [Task(1)]
    public void Get_Precision_1()
    {
        var wm = new WeighingMachine(precision: 1);
        Assert.Equal(1, wm.Precision);
    }

    [Fact]
    [Task(2)]
    public void Set_weight_and_get_weight()
    {
        var wm = new WeighingMachine(precision: 3);
        wm.Weight = 60.567;
        Assert.Equal(60.567, wm.Weight, precision:3);
    }

    [Fact]
    [Task(3)]
    public void Negative_weight_is_invalid()
    {
        var wm = new WeighingMachine(precision: 3);
        Assert.Throws<ArgumentOutOfRangeException>(() => wm.Weight = -10);
    }

    [Fact]
    [Task(4)]
    public void Apply_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine(precision: 3);
        wm.Weight = 100.770;
        wm.TareAdjustment = 10;
        Assert.Equal("90.770 kg", wm.DisplayWeight);
    }

    [Fact]
    [Task(4)]
    public void Apply_tare_adjustment_and_get_display_weight_with_precision_1()
    {
        var wm = new WeighingMachine(precision: 1);
        wm.Weight = 100.770;
        wm.TareAdjustment = 10;
        Assert.Equal("90.8 kg", wm.DisplayWeight);
    }

    [Fact]
    [Task(5)]
    public void Apply_Default_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine(precision: 3);
        wm.Weight = 100.567;
        Assert.Equal("95.567 kg", wm.DisplayWeight);
    }

    [Fact]
    [Task(6)]
    public void Apply_negative_tare_adjustment_and_get_display_weight()
    {
        var wm = new WeighingMachine(precision: 3);
        wm.Weight = 100;
        wm.TareAdjustment = -10.567;
        Assert.Equal("110.567 kg", wm.DisplayWeight);
    }

    [Fact]
    [Task(6)]
    public void Apply_large_tare_adjustment_to_allow_negative_display_weight()
    {
        var wm = new WeighingMachine(precision: 3);
        wm.Weight = 100;
        wm.TareAdjustment = 110.567;
        Assert.Equal("-10.567 kg", wm.DisplayWeight);
    }
}
