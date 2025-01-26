using Xunit;

public class DifferenceOfSquaresTests
{
    [Fact]
    public void SquareOfSum1()
    {
        Assert.Equal(1, DifferenceOfSquares.CalculateSquareOfSum(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SquareOfSum5()
    {
        Assert.Equal(225, DifferenceOfSquares.CalculateSquareOfSum(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SquareOfSum100()
    {
        Assert.Equal(25502500, DifferenceOfSquares.CalculateSquareOfSum(100));
    }
}
