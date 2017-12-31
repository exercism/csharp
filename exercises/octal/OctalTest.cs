using Xunit;

public class OctalTest
{
    [Fact]
    public void Octal_1_is_decimal_1()
    {
        Assert.Equal(1, Octal.ToDecimal("1"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_10_is_decimal_8()
    {
        Assert.Equal(8, Octal.ToDecimal("10"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_17_is_decimal_15()
    {
        Assert.Equal(15, Octal.ToDecimal("17"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_11_is_decimal_9()
    {
        Assert.Equal(9, Octal.ToDecimal("11"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_130_is_decimal_88()
    {
        Assert.Equal(88, Octal.ToDecimal("130"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_2047_is_decimal_1063()
    {
        Assert.Equal(1063, Octal.ToDecimal("2047"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_7777_is_decimal_4095()
    {
        Assert.Equal(4095, Octal.ToDecimal("7777"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_1234567_is_decimal_342391()
    {
        Assert.Equal(342391, Octal.ToDecimal("1234567"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_011_is_decimal_9()
    {
        Assert.Equal(9, Octal.ToDecimal("011"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_carrot_is_decimal_0()
    {
        Assert.Equal(0, Octal.ToDecimal("carrot"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_8_is_decimal_0()
    {
        Assert.Equal(0, Octal.ToDecimal("8"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_9_is_decimal_0()
    {
        Assert.Equal(0, Octal.ToDecimal("9"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_6789_is_decimal_0()
    {
        Assert.Equal(0, Octal.ToDecimal("6789"));
    }

    [Fact(Skip = "Remove to run test")]
    public void Octal_abc1z_is_decimal_0()
    {
        Assert.Equal(0, Octal.ToDecimal("abc1z"));
    }
}
