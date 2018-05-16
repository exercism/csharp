// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class DifferenceOfSquaresTest
{
    [Fact]
    public void Square_of_sum_1()
    {
        Assert.Equal(1, DifferenceOfSquares.CalculateSquareOfSum(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Square_of_sum_5()
    {
        Assert.Equal(225, DifferenceOfSquares.CalculateSquareOfSum(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Square_of_sum_100()
    {
        Assert.Equal(25502500, DifferenceOfSquares.CalculateSquareOfSum(100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_of_squares_1()
    {
        Assert.Equal(1, DifferenceOfSquares.CalculateSumOfSquares(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_of_squares_5()
    {
        Assert.Equal(55, DifferenceOfSquares.CalculateSumOfSquares(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Sum_of_squares_100()
    {
        Assert.Equal(338350, DifferenceOfSquares.CalculateSumOfSquares(100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_squares_1()
    {
        Assert.Equal(0, DifferenceOfSquares.CalculateDifferenceOfSquares(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_squares_5()
    {
        Assert.Equal(170, DifferenceOfSquares.CalculateDifferenceOfSquares(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Difference_of_squares_100()
    {
        Assert.Equal(25164150, DifferenceOfSquares.CalculateDifferenceOfSquares(100));
    }
}