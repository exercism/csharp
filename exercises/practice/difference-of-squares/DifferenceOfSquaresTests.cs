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

    [Fact]
    public void SumOfSquares1()
    {
        Assert.Equal(1, DifferenceOfSquares.CalculateSumOfSquares(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SumOfSquares5()
    {
        Assert.Equal(55, DifferenceOfSquares.CalculateSumOfSquares(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void SumOfSquares100()
    {
        Assert.Equal(338350, DifferenceOfSquares.CalculateSumOfSquares(100));
    }

    [Fact]
    public void DifferenceOfSquares1()
    {
        Assert.Equal(0, DifferenceOfSquares.CalculateDifferenceOfSquares(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DifferenceOfSquares5()
    {
        Assert.Equal(170, DifferenceOfSquares.CalculateDifferenceOfSquares(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void DifferenceOfSquares100()
    {
        Assert.Equal(25164150, DifferenceOfSquares.CalculateDifferenceOfSquares(100));
    }
}
