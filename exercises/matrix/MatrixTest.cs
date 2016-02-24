using NUnit.Framework;

public class MatrixTest
{
    [TestCase("1", ExpectedResult = new[] { 1 })]
    [TestCase("4 7", ExpectedResult = new[] { 4, 7 }, Ignore = "Remove to run test case")]
    [TestCase("1 2\n10 20", ExpectedResult = new[] { 1, 2 }, Ignore = "Remove to run test case")]
    [TestCase("9 7 6\n8 6 5\n5 3 2", ExpectedResult = new[] { 9, 7, 6 }, Ignore = "Remove to run test case")]
    public int[] Extract_first_row(string input)
    {
        var matrix = new Matrix(input);
        return matrix.Row(0);
    }

    [TestCase("5", ExpectedResult = new[] { 5 }, Ignore = "Remove to run test case")]
    [TestCase("9 7", ExpectedResult = new[] { 9, 7 }, Ignore = "Remove to run test case")]
    [TestCase("9 8 7\n19 18 17", ExpectedResult = new[] { 19, 18, 17 }, Ignore = "Remove to run test case")]
    [TestCase("1 4 9\n16 25 36\n5 6 7", ExpectedResult = new[] { 5, 6, 7 }, Ignore = "Remove to run test case")]
    public int[] Extract_last_row(string input)
    {
        var matrix = new Matrix(input);
        return matrix.Row(matrix.Rows - 1);
    }

    [TestCase("55 44", ExpectedResult = new[] { 55 }, Ignore = "Remove to run test case")]
    [TestCase("89 1903\n18 3", ExpectedResult = new[] { 89, 18 }, Ignore = "Remove to run test case")]
    [TestCase("1 2 3\n4 5 6\n7 8 9\n8 7 6", ExpectedResult = new[] { 1, 4, 7, 8 }, Ignore = "Remove to run test case")]
    public int[] Extract_first_column(string input)
    {
        var matrix = new Matrix(input);
        return matrix.Col(0);
    }

    [TestCase("28", ExpectedResult = new[] { 28 }, Ignore = "Remove to run test case")]
    [TestCase("13\n16\n19", ExpectedResult = new[] { 13, 16, 19 }, Ignore = "Remove to run test case")]
    [TestCase("289 21903 23\n218 23 21", ExpectedResult = new[] { 23, 21 }, Ignore = "Remove to run test case")]
    [TestCase("11 12 13\n14 15 16\n17 18 19\n18 17 16", ExpectedResult = new[] { 13, 16, 19, 16 }, Ignore = "Remove to run test case")]
    public int[] Extract_last_column(string input)
    {
        var matrix = new Matrix(input);
        return matrix.Col(matrix.Cols - 1);
    }

    [TestCase("28", ExpectedResult = 1, Ignore = "Remove to run test case")]
    [TestCase("13\n16", ExpectedResult = 2, Ignore = "Remove to run test case")]
    [TestCase("289 21903\n23 218\n23 21", ExpectedResult = 3, Ignore = "Remove to run test case")]
    [TestCase("11 12 13\n14 15 16\n17 18 19\n18 17 16", ExpectedResult = 4, Ignore = "Remove to run test case")]
    public int Number_of_rows(string input)
    {
        var matrix = new Matrix(input);
        return matrix.Rows;
    }

    [TestCase("28", ExpectedResult = 1, Ignore = "Remove to run test case")]
    [TestCase("13 2\n16 3\n19 4", ExpectedResult = 2, Ignore = "Remove to run test case")]
    [TestCase("289 21903\n23 218\n23 21", ExpectedResult = 2, Ignore = "Remove to run test case")]
    [TestCase("11 12 13\n14 15 16\n17 18 19\n18 17 16", ExpectedResult = 3, Ignore = "Remove to run test case")]
    public int Number_of_columns(string input)
    {
        var matrix = new Matrix(input);
        return matrix.Cols;
    }
}