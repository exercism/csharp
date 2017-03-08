using Xunit;

public class MatrixTest
{
    [Theory]
    [InlineData("1", new[] { 1 })]
    [InlineData("4 7", new[] { 4, 7 })]
    [InlineData("1 2\n10 20", new[] { 1, 2 })]
    [InlineData("9 7 6\n8 6 5\n5 3 2", new[] { 9, 7, 6 })]
    public void Extract_first_row(string input, int[] expected)
    {
        var matrix = new Matrix(input);
        Assert.Equal(expected, matrix.Row(0));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("5", new[] { 5 })]
    [InlineData("9 7", new[] { 9, 7 })]
    [InlineData("9 8 7\n19 18 17", new[] { 19, 18, 17 })]
    [InlineData("1 4 9\n16 25 36\n5 6 7", new[] { 5, 6, 7 })]
    public void Extract_last_row(string input, int[] expected)
    {
        var matrix = new Matrix(input);
        Assert.Equal(expected, matrix.Row(matrix.Rows - 1));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("55 44", new[] { 55 })]
    [InlineData("89 1903\n18 3", new[] { 89, 18 })]
    [InlineData("1 2 3\n4 5 6\n7 8 9\n8 7 6", new[] { 1, 4, 7, 8 })]
    public void Extract_first_column(string input, int[] expected)
    {
        var matrix = new Matrix(input);
        Assert.Equal(expected, matrix.Col(0));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("28", new[] { 28 })]
    [InlineData("13\n16\n19", new[] { 13, 16, 19 })]
    [InlineData("289 21903 23\n218 23 21", new[] { 23, 21 })]
    [InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", new[] { 13, 16, 19, 16 })]
    public void Extract_last_column(string input, int[] expected)
    {
        var matrix = new Matrix(input);
        Assert.Equal(expected, matrix.Col(matrix.Cols - 1));
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("28", 1)]
    [InlineData("13\n16", 2)]
    [InlineData("289 21903\n23 218\n23 21", 3)]
    [InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", 4)]
    public void Number_of_rows(string input, int expected)
    {
        var matrix = new Matrix(input);
        Assert.Equal(expected, matrix.Rows);
    }

    [Theory(Skip = "Remove to run test")]
    [InlineData("28", 1)]
    [InlineData("13 2\n16 3\n19 4", 2)]
    [InlineData("289 21903\n23 218\n23 21", 2)]
    [InlineData("11 12 13\n14 15 16\n17 18 19\n18 17 16", 3)]
    public void Number_of_columns(string input, int expected)
    {
        var matrix = new Matrix(input);
        Assert.Equal(expected, matrix.Cols);
    }
}