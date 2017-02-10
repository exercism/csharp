using System;
using Xunit;

public class DifferenceOfSquaresTests
{
    [Fact]
    public void Test_square_of_sums_to_5()
    {
        Assert.Equal(225, new Squares(5).SquareOfSums());
    }

    [Fact]
    public void Test_sum_of_squares_to_5()
    {
        Assert.Equal(55, new Squares(5).SumOfSquares());
    }

    [Fact]
    public void Test_difference_of_sums_to_5()
    {
        Assert.Equal(170, new Squares(5).DifferenceOfSquares());
    }

    [Fact]
    public void Test_square_of_sums_to_10()
    {
        Assert.Equal(3025, new Squares(10).SquareOfSums());
    }

    [Fact]
    public void Test_sum_of_squares_to_10()
    {
        Assert.Equal(385, new Squares(10).SumOfSquares());
    }

    [Fact]
    public void Test_difference_of_sums_to_10()
    {
        Assert.Equal(2640, new Squares(10).DifferenceOfSquares());
    }

    [Fact]
    public void Test_square_of_sums_to_100()
    {
        Assert.Equal(25502500, new Squares(100).SquareOfSums());
    }

    [Fact]
    public void Test_sum_of_squares_to_100()
    {
        Assert.Equal(338350, new Squares(100).SumOfSquares());
    }

    [Fact]
    public void Test_difference_of_sums_to_100()
    {
        Assert.Equal(25164150, new Squares(100).DifferenceOfSquares());
    }

    [Fact]
    public void Test_difference_of_sums_0()
    {
        Assert.Equal(0, new Squares(0).DifferenceOfSquares());
    }

    [Fact]
    public void Test_negative_numbers_throw_argument_out_of_range_exception()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new Squares(-5));
    }
}
