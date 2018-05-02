// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class MatrixTest
{
    [Fact]
    public void Extract_row_from_one_number_matrix()
    {
        var sut = new Matrix("1");
        Assert.Equal(new[] { 1 }, sut.Row(0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_extract_row()
    {
        var sut = new Matrix("1 2\n3 4");
        Assert.Equal(new[] { 3, 4 }, sut.Row(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Extract_row_where_numbers_have_different_widths()
    {
        var sut = new Matrix("1 2\n10 20");
        Assert.Equal(new[] { 10, 20 }, sut.Row(1));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_extract_row_from_non_square_matrix()
    {
        var sut = new Matrix("1 2 3\n4 5 6\n7 8 9\n8 7 6");
        Assert.Equal(new[] { 7, 8, 9 }, sut.Row(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Extract_column_from_one_number_matrix()
    {
        var sut = new Matrix("1");
        Assert.Equal(new[] { 1 }, sut.Column(0));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_extract_column()
    {
        var sut = new Matrix("1 2 3\n4 5 6\n7 8 9");
        Assert.Equal(new[] { 3, 6, 9 }, sut.Column(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Can_extract_column_from_non_square_matrix()
    {
        var sut = new Matrix("1 2 3\n4 5 6\n7 8 9\n8 7 6");
        Assert.Equal(new[] { 3, 6, 9, 6 }, sut.Column(2));
    }

    [Fact(Skip = "Remove to run test")]
    public void Extract_column_where_numbers_have_different_widths()
    {
        var sut = new Matrix("89 1903 3\n18 3 1\n9 4 800");
        Assert.Equal(new[] { 1903, 3, 4 }, sut.Column(1));
    }
}