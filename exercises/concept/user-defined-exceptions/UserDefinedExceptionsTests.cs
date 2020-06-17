using System;
using Xunit;

public class UserDefinedExceptionsTests
{
    [Fact]
    public void Multiply_with_overflow_throws_calculationexception()
    {
        var cth = new CalculatorTestHarness(new Calculator());

        Assert.Throws<CalculationException>(() => cth.Multiply(Int32.MaxValue, Int32.MaxValue));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TestMultiplication_with_negative_overflow()
    {
        var cth = new CalculatorTestHarness(new Calculator());
        Assert.Equal("Multiply failed for negative operands. Arithmetic operation resulted in an overflow.",
            cth.TestMultiplication(-2, -Int32.MaxValue));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void TestMultiplication_with_positive_overflow()
    {
        var cth = new CalculatorTestHarness(new Calculator());
        Assert.Equal("Multiply failed for mixed or positive operands. Arithmetic operation resulted in an overflow.",
            cth.TestMultiplication(Int32.MaxValue, Int32.MaxValue));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Call_TestMultiplication_with_success()
    {
        var cth = new CalculatorTestHarness(new Calculator());
        Assert.Equal("Multiply succeeded", cth.TestMultiplication(6, 7));
    }
}
