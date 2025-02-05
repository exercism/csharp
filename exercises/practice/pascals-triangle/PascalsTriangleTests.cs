using Xunit;

public class PascalsTriangleTests
{
    [Fact]
    public void Zero_rows()
    {
        Assert.Empty(PascalsTriangle.Calculate(0));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Single_row()
    {
        int[][] expected = [
            [1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Two_rows()
    {
        int[][] expected = [
            [1],
            [1, 1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Three_rows()
    {
        int[][] expected = [
            [1],
            [1, 1],
            [1, 2, 1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Four_rows()
    {
        int[][] expected = [
            [1],
            [1, 1],
            [1, 2, 1],
            [1, 3, 3, 1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Five_rows()
    {
        int[][] expected = [
            [1],
            [1, 1],
            [1, 2, 1],
            [1, 3, 3, 1],
            [1, 4, 6, 4, 1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(5));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Six_rows()
    {
        int[][] expected = [
            [1],
            [1, 1],
            [1, 2, 1],
            [1, 3, 3, 1],
            [1, 4, 6, 4, 1],
            [1, 5, 10, 10, 5, 1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(6));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Ten_rows()
    {
        int[][] expected = [
            [1],
            [1, 1],
            [1, 2, 1],
            [1, 3, 3, 1],
            [1, 4, 6, 4, 1],
            [1, 5, 10, 10, 5, 1],
            [1, 6, 15, 20, 15, 6, 1],
            [1, 7, 21, 35, 35, 21, 7, 1],
            [1, 8, 28, 56, 70, 56, 28, 8, 1],
            [1, 9, 36, 84, 126, 126, 84, 36, 9, 1]
        ];
        Assert.Equal(expected, PascalsTriangle.Calculate(10));
    }
}
