public class MatrixTests
{
    [Fact]
    public void Extract_row_from_one_number_matrix()
    {
        var sut = new Matrix("1");
        int[] expected = [1];
        Assert.Equal(expected, sut.Row(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_extract_row()
    {
        var sut = new Matrix("1 2\n3 4");
        int[] expected = [3, 4];
        Assert.Equal(expected, sut.Row(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Extract_row_where_numbers_have_different_widths()
    {
        var sut = new Matrix("1 2\n10 20");
        int[] expected = [10, 20];
        Assert.Equal(expected, sut.Row(2));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_extract_row_from_non_square_matrix_with_no_corresponding_column()
    {
        var sut = new Matrix("1 2 3\n4 5 6\n7 8 9\n8 7 6");
        int[] expected = [8, 7, 6];
        Assert.Equal(expected, sut.Row(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Extract_column_from_one_number_matrix()
    {
        var sut = new Matrix("1");
        int[] expected = [1];
        Assert.Equal(expected, sut.Column(1));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_extract_column()
    {
        var sut = new Matrix("1 2 3\n4 5 6\n7 8 9");
        int[] expected = [3, 6, 9];
        Assert.Equal(expected, sut.Column(3));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Can_extract_column_from_non_square_matrix_with_no_corresponding_row()
    {
        var sut = new Matrix("1 2 3 4\n5 6 7 8\n9 8 7 6");
        int[] expected = [4, 8, 6];
        Assert.Equal(expected, sut.Column(4));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Extract_column_where_numbers_have_different_widths()
    {
        var sut = new Matrix("89 1903 3\n18 3 1\n9 4 800");
        int[] expected = [1903, 3, 4];
        Assert.Equal(expected, sut.Column(2));
    }
}
