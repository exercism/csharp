// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class RomanNumeralsTest
{
    [Fact]
    public void Number_1_is_a_single_i()
    {
        Assert.Equal("I", 1.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_2_is_two_is()
    {
        Assert.Equal("II", 2.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_3_is_three_is()
    {
        Assert.Equal("III", 3.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_4_being_5_1_is_iv()
    {
        Assert.Equal("IV", 4.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_5_is_a_single_v()
    {
        Assert.Equal("V", 5.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_6_being_5_1_is_vi()
    {
        Assert.Equal("VI", 6.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_9_being_10_1_is_ix()
    {
        Assert.Equal("IX", 9.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_20_is_two_xs()
    {
        Assert.Equal("XXVII", 27.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_48_is_not_50_2_but_rather_40_8()
    {
        Assert.Equal("XLVIII", 48.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_49_is_not_40_5_4_but_rather_50_10_10_1()
    {
        Assert.Equal("XLIX", 49.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_50_is_a_single_l()
    {
        Assert.Equal("LIX", 59.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_90_being_100_10_is_xc()
    {
        Assert.Equal("XCIII", 93.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_100_is_a_single_c()
    {
        Assert.Equal("CXLI", 141.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_60_being_50_10_is_lx()
    {
        Assert.Equal("CLXIII", 163.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_400_being_500_100_is_cd()
    {
        Assert.Equal("CDII", 402.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_500_is_a_single_d()
    {
        Assert.Equal("DLXXV", 575.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_900_being_1000_100_is_cm()
    {
        Assert.Equal("CMXI", 911.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_1000_is_a_single_m()
    {
        Assert.Equal("MXXIV", 1024.ToRoman());
    }

    [Fact(Skip = "Remove to run test")]
    public void Number_3000_is_three_ms()
    {
        Assert.Equal("MMM", 3000.ToRoman());
    }
}