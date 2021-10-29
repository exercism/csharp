using Xunit;
using Exercism.Tests;
using System;

public class CalculatorConundrumTests
{
    //Addition tests
    [Fact]
    [Task(1)]
    public void Addition_with_small_operands()
    {
        Assert.Equal("22 + 25 = 47", SimpleCalculator.Calculate(22, 25, "+"));
    }

    [Fact]
    [Task(1)]
    public void Addition_with_large_operands()
    {
        Assert.Equal("378961 + 399635 = 778596", SimpleCalculator.Calculate(378_961, 399_635, "+"));
    }

    //Multiplication tests
    [Fact]
    [Task(1)]
    public void Multiplication_with_small_operands()
    {
        Assert.Equal("3 * 21 = 63", SimpleCalculator.Calculate(3, 21, "*"));
    }

    [Fact]
    [Task(1)]
    public void Multiplication_with_large_operands()
    {
        Assert.Equal("72441 * 2048 = 148359168", SimpleCalculator.Calculate(72_441, 2_048, "*"));
    }

    //Division tests
    [Fact]
    [Task(1)]
    public void Division_with_small_operands()
    {
        Assert.Equal("72 / 9 = 8", SimpleCalculator.Calculate(72, 9, "/"));
    }

    [Fact]
    [Task(1)]
    public void Division_with_large_operands()
    {
        Assert.Equal("1338800 / 83675 = 16", SimpleCalculator.Calculate(1_338_800, 83_675, "/"));
    }

    // Invalid operator
    [Fact]
    [Task(2)]
    public void Calculate_throws_exception_for_non_valid_operations()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SimpleCalculator.Calculate(1, 2, "**"));
    }

    [Fact]
    [Task(2)]
    public void Calculate_throws_exception_for_null_as_operation()
    {
        Assert.Throws<ArgumentNullException>(() => SimpleCalculator.Calculate(1, 2, null));
    }

    [Fact]
    [Task(2)]
    public void Calculate_throws_exception_for_empty_string_as_operation()
    {
        Assert.Throws<ArgumentException>(() => SimpleCalculator.Calculate(1, 2, ""));
    }

    [Fact]
    [Task(3)]
    public void Calculate_throws_exception_for_division_with_0()
    {
        Assert.Equal("Division by zero is not allowed.", SimpleCalculator.Calculate(33, 0, "/"));
    }
}
