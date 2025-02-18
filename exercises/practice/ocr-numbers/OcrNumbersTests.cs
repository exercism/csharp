public class OcrNumbersTests
{
    [Fact]
    public void Recognizes_0()
    {
        var rows =
            " _ \n" +
            "| |\n" +
            "|_|\n" +
            "   ";
        Assert.Equal("0", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_1()
    {
        var rows =
            "   \n" +
            "  |\n" +
            "  |\n" +
            "   ";
        Assert.Equal("1", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Unreadable_but_correctly_sized_inputs_return()
    {
        var rows =
            "   \n" +
            "  _\n" +
            "  |\n" +
            "   ";
        Assert.Equal("?", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Input_with_a_number_of_lines_that_is_not_a_multiple_of_four_raises_an_error()
    {
        var rows =
            " _ \n" +
            "| |\n" +
            "   ";
        Assert.Throws<ArgumentException>(() => OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Input_with_a_number_of_columns_that_is_not_a_multiple_of_three_raises_an_error()
    {
        var rows =
            "    \n" +
            "   |\n" +
            "   |\n" +
            "    ";
        Assert.Throws<ArgumentException>(() => OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_110101100()
    {
        var rows =
            "       _     _        _  _ \n" +
            "  |  || |  || |  |  || || |\n" +
            "  |  ||_|  ||_|  |  ||_||_|\n" +
            "                           ";
        Assert.Equal("110101100", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Garbled_numbers_in_a_string_are_replaced_with()
    {
        var rows =
            "       _     _           _ \n" +
            "  |  || |  || |     || || |\n" +
            "  |  | _|  ||_|  |  ||_||_|\n" +
            "                           ";
        Assert.Equal("11?10?1?0", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_2()
    {
        var rows =
            " _ \n" +
            " _|\n" +
            "|_ \n" +
            "   ";
        Assert.Equal("2", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_3()
    {
        var rows =
            " _ \n" +
            " _|\n" +
            " _|\n" +
            "   ";
        Assert.Equal("3", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_4()
    {
        var rows =
            "   \n" +
            "|_|\n" +
            "  |\n" +
            "   ";
        Assert.Equal("4", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_5()
    {
        var rows =
            " _ \n" +
            "|_ \n" +
            " _|\n" +
            "   ";
        Assert.Equal("5", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_6()
    {
        var rows =
            " _ \n" +
            "|_ \n" +
            "|_|\n" +
            "   ";
        Assert.Equal("6", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_7()
    {
        var rows =
            " _ \n" +
            "  |\n" +
            "  |\n" +
            "   ";
        Assert.Equal("7", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_8()
    {
        var rows =
            " _ \n" +
            "|_|\n" +
            "|_|\n" +
            "   ";
        Assert.Equal("8", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_9()
    {
        var rows =
            " _ \n" +
            "|_|\n" +
            " _|\n" +
            "   ";
        Assert.Equal("9", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Recognizes_string_of_decimal_numbers()
    {
        var rows =
            "    _  _     _  _  _  _  _  _ \n" +
            "  | _| _||_||_ |_   ||_||_|| |\n" +
            "  ||_  _|  | _||_|  ||_| _||_|\n" +
            "                              ";
        Assert.Equal("1234567890", OcrNumbers.Convert(rows));
    }

    [Fact(Skip = "Remove this Skip property to run this test")]
    public void Numbers_separated_by_empty_lines_are_recognized_lines_are_joined_by_commas()
    {
        var rows =
            "    _  _ \n" +
            "  | _| _|\n" +
            "  ||_  _|\n" +
            "         \n" +
            "    _  _ \n" +
            "|_||_ |_ \n" +
            "  | _||_|\n" +
            "         \n" +
            " _  _  _ \n" +
            "  ||_||_|\n" +
            "  ||_| _|\n" +
            "         ";
        Assert.Equal("123,456,789", OcrNumbers.Convert(rows));
    }
}
