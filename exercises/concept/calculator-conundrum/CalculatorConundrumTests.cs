using Xunit;
using System;
public class SimpleCalculatorTests
{
    //Addition tests
    [Fact]
    public void Addition_with_small_operands()
    {
        Assert.Equal("22 + 25 = 47", SimpleCalculator.Calculate(22, 25, "+"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_with_large_operands()
    {
        Assert.Equal("378961 + 399635 = 778596", SimpleCalculator.Calculate(378_961, 399_635, "+"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Addition_that_overflows()
    {
        Assert.Equal("The result of operation 2147483647 + 5 does not fit into integer type.", SimpleCalculator.Calculate(Int32.MaxValue, 5, "+"));
    }

    //Multiplication tests
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiplication_with_small_operands()
    {
        Assert.Equal("3 * 21 = 63", SimpleCalculator.Calculate(3, 21, "*"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiplication_with_large_operands()
    {
        Assert.Equal("72441 * 2048 = 148359168", SimpleCalculator.Calculate(72_441, 2_048, "*"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Multiplication_that_overflows()
    {
        Assert.Equal("The result of operation 50000 * 50000 does not fit into integer type.", SimpleCalculator.Calculate(50_000, 50_000, "*"));
    }

    //Division tests
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Division_with_small_operands()
    {
        Assert.Equal("72 / 9 = 8", SimpleCalculator.Calculate(72, 9, "/"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Division_with_large_operands()
    {
        Assert.Equal("1338800 / 83675 = 16", SimpleCalculator.Calculate(1_338_800, 83_675, "/"));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_throws_exception_for_division_with_0()
    {
        Assert.Equal("Division by zero is not allowed.", SimpleCalculator.Calculate(33, 0, "/"));      
    }

    // Invalid operator
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_throws_exception_for_non_valid_operations()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SimpleCalculator.Calculate(1, 2, "**"));
    }
    
    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_throws_exception_for_null_as_operation()
    {
        Assert.Throws<ArgumentNullException>(() => SimpleCalculator.Calculate(1, 2, null));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Calculate_throws_exception_for_emtpy_string_as_operation()
    {
        Assert.Throws<ArgumentException>(() => SimpleCalculator.Calculate(1, 2, ""));
    }
}