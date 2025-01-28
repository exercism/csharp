using Xunit;

public class DifferenceOfSquaresTests
{
    [Fact]
    public void Square_of_sum1()
    {
        Assert.Equal(1, DifferenceOfSquares.CalculateSquareOfSum(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Square_of_sum5()
    {
        Assert.Equal(225, DifferenceOfSquares.CalculateSquareOfSum(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Square_of_sum100()
    {
        Assert.Equal(25502500, DifferenceOfSquares.CalculateSquareOfSum(100));
    }

    [Fact]
    public void Sum_of_squares1()
    {
        Assert.Equal(1, DifferenceOfSquares.CalculateSumOfSquares(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sum_of_squares5()
    {
        Assert.Equal(55, DifferenceOfSquares.CalculateSumOfSquares(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Sum_of_squares100()
    {
        Assert.Equal(338350, DifferenceOfSquares.CalculateSumOfSquares(100));
    }

    [Fact]
    public void Difference_of_squares1()
    {
        Assert.Equal(0, DifferenceOfSquares.CalculateDifferenceOfSquares(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_of_squares5()
    {
        Assert.Equal(170, DifferenceOfSquares.CalculateDifferenceOfSquares(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Difference_of_squares100()
    {
        Assert.Equal(25164150, DifferenceOfSquares.CalculateDifferenceOfSquares(100));
    }
}
