// This file was auto-generated based on version 1.0.0 of the canonical data.

using Xunit;
using System;

public class OcrNumbersTest
{
    [Fact]
    public void Recognizes_0()
    {
        var input =  " _ " + "\n" +
                     "| |" + "\n" +
                     "|_|" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("0", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_1()
    {
        var input =  "   " + "\n" +
                     "  |" + "\n" +
                     "  |" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("1", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Unreadable_but_correctly_sized_inputs_return_()
    {
        var input =  "   " + "\n" +
                     "  _" + "\n" +
                     "  |" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("?", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_with_a_number_of_lines_that_is_not_a_multiple_of_four_raises_an_error()
    {
        var input =  " _ " + "\n" +
                     "| |" + "\n" +
                     "   ";
        Assert.Throws<ArgumentException>(() => OcrNumbers.Convert(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Input_with_a_number_of_columns_that_is_not_a_multiple_of_three_raises_an_error()
    {
        var input =  "    " + "\n" +
                     "   |" + "\n" +
                     "   |" + "\n" +
                     "    ";
        Assert.Throws<ArgumentException>(() => OcrNumbers.Convert(input));
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_110101100()
    {
        var input =  "       _     _        _  _ " + "\n" +
                     "  |  || |  || |  |  || || |" + "\n" +
                     "  |  ||_|  ||_|  |  ||_||_|" + "\n" +
                     "                           ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("110101100", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Garbled_numbers_in_a_string_are_replaced_with_()
    {
        var input =  "       _     _           _ " + "\n" +
                     "  |  || |  || |     || || |" + "\n" +
                     "  |  | _|  ||_|  |  ||_||_|" + "\n" +
                     "                           ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("11?10?1?0", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_2()
    {
        var input =  " _ " + "\n" +
                     " _|" + "\n" +
                     "|_ " + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("2", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_3()
    {
        var input =  " _ " + "\n" +
                     " _|" + "\n" +
                     " _|" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("3", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_4()
    {
        var input =  "   " + "\n" +
                     "|_|" + "\n" +
                     "  |" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("4", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_5()
    {
        var input =  " _ " + "\n" +
                     "|_ " + "\n" +
                     " _|" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("5", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_6()
    {
        var input =  " _ " + "\n" +
                     "|_ " + "\n" +
                     "|_|" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("6", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_7()
    {
        var input =  " _ " + "\n" +
                     "  |" + "\n" +
                     "  |" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("7", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_8()
    {
        var input =  " _ " + "\n" +
                     "|_|" + "\n" +
                     "|_|" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("8", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_9()
    {
        var input =  " _ " + "\n" +
                     "|_|" + "\n" +
                     " _|" + "\n" +
                     "   ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("9", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Recognizes_string_of_decimal_numbers()
    {
        var input =  "    _  _     _  _  _  _  _  _ " + "\n" +
                     "  | _| _||_||_ |_   ||_||_|| |" + "\n" +
                     "  ||_  _|  | _||_|  ||_| _||_|" + "\n" +
                     "                              ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("1234567890", actual);
    }

    [Fact(Skip = "Remove to run test")]
    public void Numbers_separated_by_empty_lines_are_recognized_lines_are_joined_by_commas_()
    {
        var input =  "    _  _ " + "\n" +
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
                     "         ";
        var actual = OcrNumbers.Convert(input);
        Assert.Equal("123,456,789", actual);
    }
}