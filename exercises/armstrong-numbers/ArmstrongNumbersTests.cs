// This file was auto-generated based on version 1.1.0 of the canonical data.

using Xunit;

public class ArmstrongNumbersTests
{
    [Fact]
    public void Zero_is_an_armstrong_number()
    {
        Assert.True(ArmstrongNumbers.IsArmstrongNumber(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_digit_numbers_are_armstrong_numbers()
    {
        Assert.True(ArmstrongNumbers.IsArmstrongNumber(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void There_are_no_2_digit_armstrong_numbers()
    {
        Assert.False(ArmstrongNumbers.IsArmstrongNumber(10));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_digit_number_that_is_an_armstrong_number()
    {
        Assert.True(ArmstrongNumbers.IsArmstrongNumber(153));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_digit_number_that_is_not_an_armstrong_number()
    {
        Assert.False(ArmstrongNumbers.IsArmstrongNumber(100));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_digit_number_that_is_an_armstrong_number()
    {
        Assert.True(ArmstrongNumbers.IsArmstrongNumber(9474));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_digit_number_that_is_not_an_armstrong_number()
    {
        Assert.False(ArmstrongNumbers.IsArmstrongNumber(9475));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Seven_digit_number_that_is_an_armstrong_number()
    {
        Assert.True(ArmstrongNumbers.IsArmstrongNumber(9926315));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Seven_digit_number_that_is_not_an_armstrong_number()
    {
        Assert.False(ArmstrongNumbers.IsArmstrongNumber(9926314));
    }
}