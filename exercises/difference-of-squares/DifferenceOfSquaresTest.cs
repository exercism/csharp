using System;
using Xunit;

public class DifferenceOfSquaresTests
{
    [Fact]
    public void Test_square_of_sums_to_5()
    {
        Assert.Equal(225, Squares.SquareOfSums(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_sum_of_squares_to_5()
    {
        Assert.Equal(55, Squares.SumOfSquares(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_difference_of_sums_to_5()
    {
        Assert.Equal(170, Squares.DifferenceOfSquares(5));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_of_sums_to_10()
    {
        Assert.Equal(3025, Squares.SquareOfSums(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_sum_of_squares_to_10()
    {
        Assert.Equal(385, Squares.SumOfSquares(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_difference_of_sums_to_10()
    {
        Assert.Equal(2640, Squares.DifferenceOfSquares(10));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_square_of_sums_to_100()
    {
        Assert.Equal(25502500, Squares.SquareOfSums(100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_sum_of_squares_to_100()
    {
        Assert.Equal(338350, Squares.SumOfSquares(100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_difference_of_sums_to_100()
    {
        Assert.Equal(25164150, Squares.DifferenceOfSquares(100));
    }

    [Fact(Skip = "Remove to run test")]
    public void Test_difference_of_sums_0()
    {
        Assert.Equal(0, Squares.DifferenceOfSquares(0));
    }
}
