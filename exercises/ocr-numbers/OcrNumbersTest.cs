// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;

public class OcrNumbersTest
{
    [Fact]
    public void Recognizes_0()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "| |" + "\n" +
        "|_|" + "\n" +
        "   ");
        Assert.Equal("0", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_1()
    {
        var converted = OcrNumbers.Convert(
        "   " + "\n" +
        "  |" + "\n" +
        "  |" + "\n" +
        "   ");
        Assert.Equal("1", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Unreadable_but_correctly_sized_inputs_return_()
    {
        var converted = OcrNumbers.Convert(
        "   " + "\n" +
        "  _" + "\n" +
        "  |" + "\n" +
        "   ");
        Assert.Equal("?", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_with_a_number_of_lines_that_is_not_a_multiple_of_four_raises_an_error()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "| |" + "\n" +
        "   ");
        Assert.Equal("-1", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_with_a_number_of_columns_that_is_not_a_multiple_of_three_raises_an_error()
    {
        var converted = OcrNumbers.Convert(
        "    " + "\n" +
        "   |" + "\n" +
        "   |" + "\n" +
        "    ");
        Assert.Equal("-1", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_110101100()
    {
        var converted = OcrNumbers.Convert(
        "       _     _        _  _ " + "\n" +
        "  |  || |  || |  |  || || |" + "\n" +
        "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
        "                           ");
        Assert.Equal("110101100", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Garbled_numbers_in_a_string_are_replaced_with_()
    {
        var converted = OcrNumbers.Convert(
        "       _     _           _ " + "\n" +
        "  |  || |  || |     || || |" + "\n" +
        "  |  | _|  ||_|  |  ||_||_|" + "\n" +
        "                           ");
        Assert.Equal("11?10?1?0", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_2()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        " _|" + "\n" +
        "|_ " + "\n" +
        "   ");
        Assert.Equal("2", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_3()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        " _|" + "\n" +
        " _|" + "\n" +
        "   ");
        Assert.Equal("3", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_4()
    {
        var converted = OcrNumbers.Convert(
        "   " + "\n" +
        "|_|" + "\n" +
        "  |" + "\n" +
        "   ");
        Assert.Equal("4", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_5()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "|_ " + "\n" +
        " _|" + "\n" +
        "   ");
        Assert.Equal("5", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_6()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "|_ " + "\n" +
        "|_|" + "\n" +
        "   ");
        Assert.Equal("6", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_7()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "  |" + "\n" +
        "  |" + "\n" +
        "   ");
        Assert.Equal("7", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_8()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "|_|" + "\n" +
        "|_|" + "\n" +
        "   ");
        Assert.Equal("8", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_9()
    {
        var converted = OcrNumbers.Convert(
        " _ " + "\n" +
        "|_|" + "\n" +
        " _|" + "\n" +
        "   ");
        Assert.Equal("9", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_string_of_decimal_numbers()
    {
        var converted = OcrNumbers.Convert(
        "    _  _     _  _  _  _  _  _ " + "\n" +
        "  | _| _||_||_ |_   ||_||_|| |" + "\n" +
        "  ||_  _|  | _||_|  ||_| _||_|" + "\n" +
        "                              ");
        Assert.Equal("1234567890", converted);
    }

    [Fact(Skip = "Remove to run test")]
    public void Numbers_separated_by_empty_lines_are_recognized_lines_are_joined_by_commas_()
    {
        var converted = OcrNumbers.Convert(
        "    _  _ " + "\n" +
        "  | _| _|" + "\n" +
        "  ||_  _|" + "\n" +
        "         " + "\n" +
        "    _  _ " + "\n" +
        "|_||_ |_ " + "\n" +
        "  | _||_|" + "\n" +
        "         " + "\n" +
        " _  _  _ " + "\n" +
        "  ||_||_|" + "\n" +
        "  ||_| _|" + "\n" +
        "         ");
        Assert.Equal("123,456,789", converted);
    }
}